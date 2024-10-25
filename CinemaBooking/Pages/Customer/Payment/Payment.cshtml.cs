using CinemaBooking.Model;
using CinemaBooking.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Customer.Payment;

public class PaymentModel : PageModel
    {
        private readonly IVnPayService _vnPayService;

        public PaymentModel(IVnPayService vnPayService)
        {
            _vnPayService = vnPayService;
        }

        [BindProperty]
        public VnPaymentRequestModel PaymentRequest { get; set; }


        public void OnGet()
        {
            
        }

        public IActionResult OnPost() 
        {
            // if (!ModelState.IsValid)
            // {
            //     // Lấy lỗi từ ModelState
            //     var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            //     foreach (var error in errors)
            //     {
            //         // Có thể ghi log vào console hoặc một file
            //         Console.WriteLine(error);
            //     }
            //     // Xem lỗi để biết lý do
            //     return Page();
            // }
            //
            // // Nếu hợp lệ
            // PaymentRequest.OrderId = "1";
            // PaymentRequest.CreatedDate = DateTime.Now;

            return RedirectToPage("/Admin/Account/List");
        }
    }