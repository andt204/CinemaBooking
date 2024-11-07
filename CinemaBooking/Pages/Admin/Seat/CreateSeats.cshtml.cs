using CinemaBooking.Services;
using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaBooking.Pages.Admin.Seat
{
    public class CreateSeatsModel : PageModel
    {
        private readonly RoomService _roomService;
        private readonly SeatService _seatService;
        private readonly SeatTypeService _seatTypeService;

        public CreateSeatsModel(RoomService roomService, SeatService seatService, SeatTypeService seatTypeService)
        {
            _roomService = roomService;
            _seatService = seatService;
            _seatTypeService = seatTypeService;
        }

        [BindProperty]
        public int RoomId { get; set; }

        [BindProperty]
        public List<SeatDto> Seats { get; set; } = new();

        public List<RoomDto> Rooms { get; set; } = new();
        public List<SeatTypeDto> SeatTypes { get; set; } = new();

        public async Task OnGetAsync()
        {
            // Fetch rooms and seat types for dropdowns
            Rooms = await _roomService.GetAllRoomsAsync();
            SeatTypes = await _seatTypeService.GetAllSeatTypesAsync();
        }

        // New method to fetch seats for a specific room
        public async Task<IActionResult> OnGetSeatsAsync(int roomId)
        {
            var seats = await _seatService.GetSeatsByRoomIdAsync(roomId);
            return new JsonResult(seats);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validate the number of seats against the room's capacity
            var room = await _roomService.GetRoomByIdAsync(RoomId);
            if (room == null)
            {
                ModelState.AddModelError(string.Empty, "Selected room not found.");
                return Page();
            }

            int maxCapacity = room.RoomType.NumberOfRow * room.RoomType.NumberOfColumn;

            if (Seats.Count > maxCapacity)
            {
                ModelState.AddModelError(string.Empty, $"The number of seats ({Seats.Count}) exceeds the room capacity ({maxCapacity}).");
                return Page();
            }

            // Validate individual seat rows and columns
            foreach (var seat in Seats)
            {
                //// Check if Column is within valid limits
                //if (seat.Column < 1 || seat.Column > room.RoomType.NumberOfColumn)
                //{
                //    ModelState.AddModelError(string.Empty, $"Column must be between 1 and {room.RoomType.NumberOfColumn} for seatat Row: {seat.Row}, Column: {seat.Column}.");
                //}

                // Check if the seat already exists
                if (await _seatService.SeatExistsAsync(RoomId, seat.Row.ToUpper(), seat.Column))
                {
                    ModelState.AddModelError(string.Empty, $"Seat already exists at Row: {seat.Row.ToUpper()}, Column: {seat.Column}.");
                }
            }

            // Check if there are any model state errors from the row and column validation
            if (!ModelState.IsValid)
            {
                // Reload rooms and seat types if there are validation errors
                Rooms = await _roomService.GetAllRoomsAsync();
                SeatTypes = await _seatTypeService.GetAllSeatTypesAsync();
                return Page();
            }

            // Set room ID for each seat and save them
            foreach (var seat in Seats)
            {
                seat.RoomId = RoomId;
            }

            await _seatService.CreateSeatsAsync(Seats, RoomId);

            TempData["SuccessMessage"] = "Seats successfully added!";
            return RedirectToPage("/Admin/Seat/CreateSeats");
        }
    }
}
