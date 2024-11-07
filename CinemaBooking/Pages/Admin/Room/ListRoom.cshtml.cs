using CinemaBooking.Services;
using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Admin.Room
{
    public class ListRoomModel : PageModel
    {
        private readonly RoomAdminService _roomService;

        public ListRoomModel(RoomAdminService roomService)
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
    }
}
