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
        [BindProperty]
        public int CategoryId { get; set; } // Used to identify the actor for update/delete

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
        // Method to update an existing actor
        public async Task<IActionResult> OnPostUpdateAsync()
        {
            var actor = await _context.Categories.FindAsync(CategoryId);
            if (actor == null)
            {
                ModelState.AddModelError("", "Category not found.");
                return Page();
            }

            actor.CategoryName = CategoryName;
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Category updated successfully!";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var actor = await _context.Categories.FindAsync(id);
            if (actor != null)
            {
                _context.Categories.Remove(actor);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Category deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Category not found.";
            }

            return RedirectToPage();
        }
    }
}
