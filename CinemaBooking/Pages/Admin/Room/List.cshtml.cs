using CinemaBooking.Enum;
using CinemaBooking.Services;
using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Admin.Room
{
    public class ListRoomModel : PageModel
    {
        private readonly RoomService _roomService;

        public ListRoomModel(RoomService roomService)
        {
            _roomService = roomService;
        }

        public List<RoomDto> Rooms { get; set; } = new();

        // Filter properties
        [BindProperty(SupportsGet = true)]
        public int? RoomId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? RoomName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? RoomType { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Status { get; set; }

        public async Task OnGetAsync()
        {
            // Fetch rooms based on filters
            Rooms = await _roomService.GetRoomsByFilterAsync(RoomId, RoomName, RoomType, Status);
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            // Set room status to Unavailable
            await _roomService.SetRoomStatusAsync(id, RoomStatus.Unavailable);

            // Set a success message and redirect to the same page
            TempData["SuccessMessage"] = "Room status set to Unavailable successfully.";
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostReactiveAsync(int id)
        {
            // Set room status to Unavailable
            await _roomService.SetRoomStatusAsync(id, RoomStatus.Available);

            // Set a success message and redirect to the same page
            TempData["SuccessMessage"] = "Room status set to Available successfully.";
            return RedirectToPage();
        }
    }
}
