using AutoMapper;
using CinemaBooking.Data;
using CinemaBooking.Enum;
using CinemaBooking.ViewModels;
using CinemaBooking.ViewModels.Request;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Services
{
    public class SeatService
    {
        private readonly CinemaBookingContext _context;
        private readonly IMapper _mapper;

        public SeatService(CinemaBookingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateSeatsAsync(List<SeatDto> seatDtos, int roomId)
        {
            // Fetch the room with its RoomType details
            var room = await _context.Rooms
                .Include(r => r.RoomType)
                .FirstOrDefaultAsync(r => r.RoomId == roomId);

            if (room == null)
            {
                throw new Exception("Room not found.");
            }

            // Calculate the maximum seat capacity
            var maxCapacity = room.RoomType.NumberOfRow.GetValueOrDefault() * room.RoomType.NumberOfColumn.GetValueOrDefault();

            // Validate the total number of seats to be created
            if (seatDtos.Count > maxCapacity)
            {
                throw new InvalidOperationException($"The total number of seats ({seatDtos.Count}) exceeds the room capacity ({maxCapacity}).");
            }

            // Create the seats
            foreach (var seatDto in seatDtos)
            {
                // Ensure Row and Column are within valid limits
                if (string.IsNullOrEmpty(seatDto.Row) || seatDto.Column < 1 || seatDto.Column > room.RoomType.NumberOfColumn)
                {
                    throw new InvalidOperationException($"Invalid Row or Column for seat: Row = {seatDto.Row}, Column = {seatDto.Column}");
                }

                // Set the RoomId for each seat
                seatDto.RoomId = roomId;
                seatDto.Row = seatDto.Row.ToUpper();
                // Map SeatDto to Seat entity
                var seat = _mapper.Map<Seat>(seatDto);
                _context.Seats.Add(seat);
            }

            await _context.SaveChangesAsync();
        }
        public async Task<bool> SeatExistsAsync(int roomId, string row, int column)
        {
            return await _context.Seats.AnyAsync(s => s.RoomId == roomId && s.Row == row && s.Column == column);
        }

        public async Task<List<SeatDto>> GetSeatsByRoomIdAsync(int roomId)
        {
            return await _context.Seats
                .Where(s => s.RoomId == roomId)
                .Select(seat => new SeatDto
                {
                    SeatId = seat.SeatId,
                    RoomId = seat.RoomId,
                    Row = seat.Row,
                    Column = seat.Column,
                    SeatTypeId = seat.SeatTypeId,
                    Status = (SeatStatus)seat.Status,
                    Room = _mapper.Map<RoomDto>(seat.Room),
                    SeatType = _mapper.Map<SeatTypeDto>(seat.SeatType),
                })
                .ToListAsync();
        }
        public async Task<List<SeatDto>> GetSeatsByIdAsync(int id)
        {
            // Assuming you have logic to fetch the seats by ID or however you determine the seats to delete
            return await _context.Seats
                .Where(seat => seat.SeatId == id)
                .Select(seat => new SeatDto
                {
                    SeatId = seat.SeatId,
                    Row = seat.Row,
                    Column = seat.Column,
                    SeatTypeId = seat.SeatTypeId,
                    Status = (SeatStatus)seat.Status
                }).ToListAsync();
        }

        public async Task<SeatDto> UpdateSeatAsync(SeatDto seat)
        {
            var existingSeat = await _context.Seats
                .FirstOrDefaultAsync(s => s.RoomId == seat.RoomId && s.Row == seat.Row && s.Column == seat.Column);

            if (existingSeat == null)
            {
                return null; // Return null if the seat doesn't exist
            }

            // Update seat properties
            existingSeat.Status = (byte)seat.Status; // Ensure the status is cast to byte
            existingSeat.SeatTypeId = seat.SeatTypeId; // Update the seat type

            _context.Seats.Update(existingSeat); // Mark the seat as modified
            await _context.SaveChangesAsync(); // Commit changes to the database

            return _mapper.Map<SeatDto>(existingSeat); // Return the updated seat as SeatDto
        }
        public async Task<Seat> GetSeatByRowAndColumnAsync(int roomId, string row, int column)
        {
            return await _context.Seats
                .FirstOrDefaultAsync(s => s.RoomId == roomId && s.Row == row && s.Column == column);
        }
    }
}
