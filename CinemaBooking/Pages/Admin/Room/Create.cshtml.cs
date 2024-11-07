using CinemaBooking.Services;
using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Admin.Room
{
    public class CreateRoomModel : PageModel
    {
        private readonly RoomService _roomService;
        private readonly RoomTypeService _roomTypeService;
        private readonly TheaterService _theaterService;

        public CreateRoomModel(RoomService roomService, RoomTypeService roomTypeService, TheaterService theaterService)
        {
            _roomService = roomService;
            _roomTypeService = roomTypeService;
            _theaterService = theaterService;
        }

        [BindProperty]
        public RoomDto Room { get; set; } = new RoomDto();

        public List<RoomTypeDto> RoomTypes { get; set; }

        public List<TheaterDto> Theaters { get; set; }

        public async Task OnGetAsync()
        {
            // Load RoomTypes from database
            RoomTypes = await _roomTypeService.GetAllRoomTypesAsync();
            Theaters = await _theaterService.GetAllTheatersAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                RoomTypes = await _roomTypeService.GetAllRoomTypesAsync();
                Theaters = await _theaterService.GetAllTheatersAsync();
                return Page();
            }

            Room.Status = Enum.RoomStatus.Available;
            await _roomService.CreateRoomAsync(Room);
            TempData["SuccessCreateRoomMessage"] = "Room created successfully.";
            return RedirectToPage("/Admin/Room/List");
        }

    }
}
