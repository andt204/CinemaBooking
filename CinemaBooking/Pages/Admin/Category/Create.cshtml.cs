using CinemaBooking.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Pages.Admin.Category
{
    public class CreateModel : PageModel
    {
        private readonly CinemaBookingContext _context;

        public CreateModel(CinemaBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string CategoryName { get; set; }

        public string ErrorMessage { get; private set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra ModelState trước
            if (!ModelState.IsValid)
                return Page();

            // Kiểm tra xem danh mục đã tồn tại chưa
            if (await _context.Categories.AnyAsync(c => c.CategoryName == CategoryName))
            {
                ModelState.AddModelError(string.Empty, "Danh mục này đã tồn tại!"); // Thêm thông báo lỗi vào ModelState
                return Page();
            }

            var category = new Data.Category { CategoryName = CategoryName };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Danh mục đã được thêm thành công!";
            return RedirectToPage("/Admin/Movie/CreateMovie");
        }

    }
}
