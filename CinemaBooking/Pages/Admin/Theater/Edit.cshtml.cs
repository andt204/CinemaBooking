using CinemaBooking.Services;
using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CinemaBooking.Pages.Admin.Theater
{
    [Authorize(Roles = "Admin")]
    public class UpdateModel : PageModel
    {
        private readonly TheaterService _theaterService;

        // Constructor
        public UpdateModel(TheaterService theaterService)
        {
            _theaterService = theaterService;
        }

        // Bind the TheaterDto for form binding
        [BindProperty]
        public TheaterDto Theater { get; set; }

        // Method to get the existing theater data by ID
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Theater = await _theaterService.GetTheaterByIdAsync(id);
            if (Theater == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Method to handle the post request for updating theater
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _theaterService.UpdateTheaterAsync(Theater);
            TempData["SuccessEditTheaterMessage"] = "Theater updated successfully!";
            return RedirectToPage("/Admin/Theater/List");
        }
    }
}
