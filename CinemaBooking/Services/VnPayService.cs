using CinemaBooking.VnPayModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
namespace CinemaBooking.Services;

public class VnPayService 
{
    private readonly IConfiguration _configuration;
    private readonly string _paymentUrl;
    private readonly string _hashSecret;

    public VnPayService(IConfiguration configuration)
    {
        _paymentUrl = configuration["VnPay:PaymentUrl"];
        _hashSecret = configuration["VnPay:HashSecret"];
        _configuration = configuration;
    }

    public string CreatePaymentUrl(int amount, string ipAddress)
    {
        var requestData = new Dictionary<string, string>
        {
            { "vnp_Version", "2.1.0" },
            { "vnp_Command", "pay" },
            { "vnp_TmnCode", _configuration["VnPay:TmnCode"] },
            { "vnp_Amount", (amount * 100).ToString() }, // Số tiền
            { "vnp_CurrCode", "VND" },
            { "vnp_TxnRef", DateTime.Now.Ticks.ToString() }, // Mã giao dịch
            { "vnp_OrderInfo", "Thanh toán đơn hàng" },
            { "vnp_Locale", "vn" },
            { "vnp_ReturnUrl", _configuration["VnPay:RedirectUrl"] },
            { "vnp_IpAddr", ipAddress },
            { "vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss") }
        };

        // Log requestData
        Console.WriteLine("Request Data:");
        foreach (var kv in requestData)
        {
            Console.WriteLine($"{kv.Key}: {kv.Value}");
        }

        var vnPay = new VnPayLibrary(requestData);
        return vnPay.CreateRequestUrl(_paymentUrl, _hashSecret);
    }
}