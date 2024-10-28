using CinemaBooking.VnPayModels;

namespace CinemaBooking.Services;

public interface IVnPayService
{
    string CreatePaymentUrl(HttpContext context, VnPaymentRequestModel model);

    VnPaymentResponseModel MakePayment(IQueryCollection colletions);
}