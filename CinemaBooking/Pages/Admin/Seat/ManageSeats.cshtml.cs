using CinemaBooking.Enum;
using CinemaBooking.Services;
using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaBooking.Pages.Admin.Seat
{
    [Authorize(Roles = "Admin")]
    public class ManageSeatsModel : PageModel
    {
        private readonly RoomService _roomService;
        private readonly SeatService _seatService;
        private readonly SeatTypeService _seatTypeService;

        public ManageSeatsModel(RoomService roomService, SeatService seatService, SeatTypeService seatTypeService)
        {
            _roomService = roomService;
            _seatService = seatService;
            _seatTypeService = seatTypeService;
        }

        [BindProperty]
        public int RoomId { get; set; } = 0; 

        [BindProperty]
        public string? Row { get; set; } = string.Empty;

        [BindProperty]
        public int Column { get; set; } = 0;

        [BindProperty]
        public int Status { get; set; } = 0;

        [BindProperty]
        public int SeatTypeId { get; set; } = 0;
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

            // Convert seat data to include only necessary properties
            var result = seats.Select(seat => new
            {
                seat.RoomId,
                seat.Row,
                seat.Column,
                seat.SeatTypeId,
                Type = seat.SeatType?.SeatTypeName, // Ensure only the name is passed
                Status = seat.Status == SeatStatus.Unavailable ? SeatStatus.Unavailable : SeatStatus.Available,
                RoomStatus = seat.Room.Status,
            });

            return new JsonResult(result);
        }


        public async Task<IActionResult> OnGetRoomDetailsAsync(int roomId)
        {
            var room = await _roomService.GetRoomByIdAsync(roomId);

            if (room == null)
            {
                return NotFound(); // Return 404 if the room is not found
            }

            // Return the room's row and column details as JSON
            var roomDetails = new
            {
                room.RoomType.NumberOfRow,
                room.RoomType.NumberOfColumn,
                room.RoomType.RoomTypeName,
                room.Status
            };

            return new JsonResult(roomDetails);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validate the room's existence
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

            // Calculate valid rows (e.g., "A", "B", "C" for NumberOfRow = 3)
            var validRows = Enumerable.Range(0, room.RoomType.NumberOfRow)
                                      .Select(i => (char)('A' + i))
                                      .ToList();

            var duplicateSeats = new HashSet<string>();

            // Validate individual seat rows and columns
            foreach (var seat in Seats)
            {
                // Check if Row is within valid limits (case insensitive)
                if (!validRows.Contains(char.ToUpper(seat.Row[0])))
                {
                    var validRowLetters = string.Join(", ", validRows);
                    ModelState.AddModelError(string.Empty, $"Row must be one of the following: {validRowLetters} for seat at Row: {seat.Row}, Column: {seat.Column}.");
                }

                // Check if Column is within valid limits
                if (seat.Column < 1 || seat.Column > room.RoomType.NumberOfColumn)
                {
                    ModelState.AddModelError(string.Empty, $"Column value for seat at Row: {seat.Row}, Column: {seat.Column} must be one of the values from 1 to {room.RoomType.NumberOfColumn}.");
                }

                // Create a unique key for each seat based on Row and Column
                var seatKey = $"{seat.Row.ToUpper()}_{seat.Column}";

                // Check if the seat already exists in the current list of seats
                if (duplicateSeats.Contains(seatKey))
                {
                    ModelState.AddModelError(string.Empty, $"Duplicate seat entry detected at Row: {seat.Row.ToUpper()}, Column: {seat.Column}.");
                }
                else
                {
                    duplicateSeats.Add(seatKey);
                }

                // Check if the seat already exists in the database
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
            return RedirectToPage("/Admin/Seat/ManageSeats");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostUpdateSeatAsync()
        {
            // Kiểm tra tính hợp lệ của các tham số đầu vào
            if (string.IsNullOrWhiteSpace(Row) || Column <= 0 || RoomId <= 0 || SeatTypeId <= 0)
            {
                return new JsonResult(new { success = false, message = "Invalid parameters provided." });
            }

            // Kiểm tra ghế có tồn tại không
            var seat = await _seatService.GetSeatByRowAndColumnAsync(RoomId, Row.ToUpper(), Column);
            if (seat == null)
            {
                return new JsonResult(new { success = false, message = "The seat does not exist." });
            }

            // Chuẩn bị đối tượng DTO cho ghế cần cập nhật
            var seatDto = new SeatDto
            {
                RoomId = RoomId,
                Row = Row.ToUpper(),
                Column = Column,
                Status = (SeatStatus)Status,
                SeatTypeId = SeatTypeId
            };

            // Gọi service để cập nhật ghế
            var updateResult = await _seatService.UpdateSeatAsync(seatDto);
            if (updateResult == null)
            {
                return new JsonResult(new { success = false, message = "Failed to update the seat." });
            }

            // Trả về thông báo thành công dưới dạng JSON
            return new JsonResult(new { success = true, message = "Seat updated successfully!" });
        }
    }
}
