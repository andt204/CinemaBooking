using CinemaBooking.Model;

namespace CinemaBooking.Service;

public interface IVnPayService
{
    string CreatePaymentUrl(HttpContext context, VnPaymentRequestModel model);

    VnPaymentResponseModel MakePayment(IQueryCollection colletions);
}