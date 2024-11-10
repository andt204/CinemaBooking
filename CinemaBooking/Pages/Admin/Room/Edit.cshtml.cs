using CinemaBooking.Services;
using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Admin.Room
{
    [Authorize(Roles = "Admin")]
    public class UpdateRoomModel : PageModel
    {
        private readonly RoomService _roomService;
        private readonly RoomTypeService _roomTypeService;
        private readonly TheaterService _theaterService;

        public UpdateRoomModel(RoomService roomService, RoomTypeService roomTypeService, TheaterService theaterService)
        {
            _roomService = roomService;
            _roomTypeService = roomTypeService;
            _theaterService = theaterService;
        }

        [BindProperty]
        public RoomDto Room { get; set; } = new RoomDto();

        public List<RoomTypeDto> RoomTypes { get; set; }
        public List<TheaterDto> Theaters { get; set; }

        public async Task<IActionResult> OnGetAsync(int roomId)
        {
            // Load RoomTypes and Theaters from the database
            RoomTypes = await _roomTypeService.GetAllRoomTypesAsync();
            Theaters = await _theaterService.GetAllTheatersAsync();

            // Retrieve the existing room details
            Room = await _roomService.GetRoomByIdAsync(roomId);
            if (Room == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Reload dropdown data if validation fails
                RoomTypes = await _roomTypeService.GetAllRoomTypesAsync();
                Theaters = await _theaterService.GetAllTheatersAsync();
                return Page();
            }

            // Update room details
            await _roomService.UpdateRoomAsync(Room);

            TempData["SuccessEditRoomMessage"] = "Room updated successfully.";
            return RedirectToPage("/Admin/Room/List");
        }
    }
}
