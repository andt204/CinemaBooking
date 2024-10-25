using AutoMapper;
using CinemaBooking.Data;
using CinemaBooking.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Services
{
	public class SeatSelectionService
	{
		private readonly CinemaBookingContext _context;
		private readonly IMapper _mapper;

		public SeatSelectionService(CinemaBookingContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

        public async Task<ShowtimeDto> GetShowtimeById(int showtimeId)
        {
            // Fetch the showtime and include related Room and RoomType data
            var showtime = await _context.Showtimes
                .Include(st => st.Room)
                    .ThenInclude(r => r.RoomType)
                .FirstOrDefaultAsync(st => st.ShowtimeId == showtimeId);

            if (showtime == null)
            {
                // Handle the case where the showtime is not found
                return null;
            }

            // Map the showtime entity to its corresponding DTO
            var showtimeDto = _mapper.Map<ShowtimeDto>(showtime);

            // Map the Room entity to RoomDto
            showtimeDto.Room = _mapper.Map<RoomDto>(showtime.Room);

            // Get the seats for the room and include SeatType
            var seats = await _context.Seats
                .Include(s => s.SeatType) // Include the SeatType for each seat
                .Where(s => s.RoomId == showtimeDto.Room.RoomId)
                .ToListAsync();

            // Map the Seat entities to SeatDto (including SeatType)
            showtimeDto.Room.Seats = _mapper.Map<List<SeatDto>>(seats);

            return showtimeDto;
        }


    }
}
