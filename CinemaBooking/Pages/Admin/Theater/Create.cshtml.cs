using CinemaBooking.Services;
using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using CinemaBooking.Enum;

namespace CinemaBooking.Pages.Admin.Theater
{
    public class AddModel : PageModel
    {
        private readonly TheaterAdminService _theaterService;

        // Constructor
        public AddModel(TheaterAdminService theaterService)
        {
            _theaterService = theaterService;
        }

        // Bind the TheaterDto for form binding
        [BindProperty]
        public TheaterDto Theater { get; set; } = new TheaterDto();

        // Method to handle the post request
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Set default status to Active
            Theater.Status = TheaterStatus.Active;

            await _theaterService.CreateTheaterAsync(Theater);
            TempData["SuccessMessage"] = "Theater created successfully.";
            return RedirectToPage("/Admin/Theater/List");
        }
    }
}
