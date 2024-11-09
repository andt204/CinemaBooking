using CinemaBooking.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Pages.Admin.Category
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly CinemaBookingContext _context;

        public CreateModel(CinemaBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string CategoryName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public List<Data.Category> CategoryList { get; set; }

        public string ErrorMessage { get; private set; }

        public async Task<IActionResult> OnGetAsync(string? title)
        {
            CategoryList = string.IsNullOrEmpty(title)
                ? await _context.Categories.ToListAsync()
                : await _context.Categories
                    .Where(a => a.CategoryName.Contains(title))
                    .ToListAsync();

            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (await _context.Categories.AnyAsync(a => a.CategoryName == CategoryName))
            {
                ModelState.AddModelError(string.Empty, "This category already exists!"); // Add error message to ModelState
                // return Page();
            }

            var category = new Data.Category { CategoryName = CategoryName };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Category has been successfully added!";
            return RedirectToPage();
        }
    }
}
