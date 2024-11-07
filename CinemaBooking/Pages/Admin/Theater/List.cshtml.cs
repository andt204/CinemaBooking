using CinemaBooking.Services;
using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using CinemaBooking.Enum;
using Microsoft.AspNetCore.Authorization;
namespace CinemaBooking.Pages.Admin.Theater;
[Authorize(Roles = "Admin")]
public class ListModel : PageModel
{

    private readonly TheaterService _theaterService;

    public ListModel(TheaterService theaterService)
    {
        _theaterService = theaterService;
    }

    public List<TheaterDto> Theaters { get; set; } = new();

    // Filter properties
    [BindProperty(SupportsGet = true)]
    public int? TheaterId { get; set; }
    [BindProperty(SupportsGet = true)]
    public string? TheaterName { get; set; }
    [BindProperty(SupportsGet = true)]
    public string? Location { get; set; }
    [BindProperty(SupportsGet = true)]
    public TheaterStatus? Status { get; set; }  // TheaterStatus is assumed as an enum

    public async Task OnGetAsync()
    {
        // Fetch theaters based on filters
        Theaters = await _theaterService.GetTheatersByFilterAsync(TheaterId, TheaterName, Location, Status);
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _theaterService.SetTheaterStatusAsync(id, TheaterStatus.Unavailable);
        return RedirectToPage();
    }
}
