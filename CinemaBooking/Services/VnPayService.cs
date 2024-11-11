using CinemaBooking.VnPayModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using CinemaBooking.Data;
using CinemaBooking.Enum;

namespace CinemaBooking.Services;

public class VnPayService : IVnPayService
{
    private readonly IConfiguration _config;
    private static MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
    private readonly CinemaBookingContext _context = new CinemaBookingContext();
    private VnPaymentRequestModel VNPaymentRequestModel { get; set; }
    
    public VnPayService(IConfiguration config)
    {
        _config = config;
    }

    public string CreatePaymentUrl(HttpContext context, VnPaymentRequestModel model)
    {
        var now = DateTime.Now;
        var tick = now.Ticks;
        var expiredDate = now.AddMinutes(15);
        var orderId = $"{model.OrderId}_{tick}";

        var vnpay = new VnPayLibrary();
        VNPaymentRequestModel = model;
        vnpay.AddRequestData("vnp_Version", _config["VnPay:Version"]);
        vnpay.AddRequestData("vnp_Command", _config["VnPay:Command"]);
        vnpay.AddRequestData("vnp_TmnCode", _config["VnPay:TmnCode"]);
        vnpay.AddRequestData("vnp_Amount", (model.Amount * 100).ToString());
        vnpay.AddRequestData("vnp_CreateDate", model.CreatedDate.ToString("yyyyMMddHHmmss"));
        vnpay.AddRequestData("vnp_CurrCode", _config["VnPay:CurrCode"]);
        vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(context));
        vnpay.AddRequestData("vnp_Locale", _config["VnPay:Locale"]);
        vnpay.AddRequestData("vnp_OrderInfo", "Thanh toán cho đơn hàng: Vé xem phim");
        vnpay.AddRequestData("vnp_OrderType", model.TicketId.ToString());
        vnpay.AddRequestData("vnp_ReturnUrl", _config["VnPay:RedirectUrl"]);
        vnpay.AddRequestData("vnp_TxnRef", orderId);
        vnpay.AddRequestData("vnp_ExpireDate", expiredDate.ToString("yyyyMMddHHmmss"));

        // Lưu ticketId vào cache với key là orderId
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(15))
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));
            
        _cache.Set(orderId, model.TicketId.ToString(), cacheEntryOptions);
        Console.WriteLine($"Saved to cache - OrderId: {orderId}, TicketId: {model.TicketId}");

        var paymentUrl = vnpay.CreateRequestUrl(_config["VnPay:PaymentUrl"], _config["VnPay:HashSecret"]);
        return paymentUrl;
    }

    public VnPaymentResponseModel MakePayment(IQueryCollection collections)
    {
        var vnpay = new VnPayLibrary();
        foreach (var (key, value) in collections)
        {
            if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
            {
                vnpay.AddResponseData(key, value.ToString());
            }
        }

        var orderInfo = vnpay.GetResponseData("vnp_OrderInfo");
        var txnRef = vnpay.GetResponseData("vnp_TxnRef");
        var transactionId = vnpay.GetResponseData("vnp_TransactionNo");
        var responseCode = vnpay.GetResponseData("vnp_ResponseCode");
        var secureHash = collections.FirstOrDefault(p => p.Key.Equals("vnp_SecureHash")).Value;
        var amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount"));
        var transactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");

        // Validate the signature
        bool checkSignature = vnpay.ValidateSignature(secureHash, _config["VnPay:HashSecret"]);
        if (!checkSignature)
        {
            return new VnPaymentResponseModel
            {
                Success = false,
               
            };
        }

        // Check transaction status and response code to ensure payment was successful
        if (responseCode != "00" || transactionStatus != "00") // Assuming "00" means success
        {
            return new VnPaymentResponseModel
            {
                Success = false,
        
            };
        }

        // Retrieve ticketId from cache
        string ticketId;
        if (!_cache.TryGetValue(txnRef, out ticketId))
        {
            Console.WriteLine($"TicketId not found in cache for OrderId: {txnRef}");
            ticketId = string.Empty;
        }
        else
        {
            Console.WriteLine($"Retrieved from cache - OrderId: {txnRef}, TicketId: {ticketId}");
            // Remove from cache after using it
            _cache.Remove(txnRef);
        }

        // Update the ticket status to indicate successful payment
        var ticket = _context.Tickets.FirstOrDefault(s => s.TicketId.ToString() == ticketId);
        if (ticket != null)
        {
            ticket.Status = 1;
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
        }

        return new VnPaymentResponseModel
        {
            Success = true,
            PaymentMethod = "VnPay",
            OrderDescription = orderInfo,
            OrderId = txnRef,
            TransactionId = transactionId,
            Token = secureHash,
            VnPayResponseCode = responseCode,
            TicketId = ticketId
        };
    }

}