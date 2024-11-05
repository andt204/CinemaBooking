using AutoMapper;
using CinemaBooking.Data;
using CinemaBooking.Enum;
using CinemaBooking.ViewModels;
using CinemaBooking.ViewModels.Request;
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

		public async Task<Ticket> CreateCustomerTicket(CreateUserTicketRequest request)
		{
			var ticketDto = new TicketDto
			{
				AccountId = request.AccountId,
				ShowtimeId = request.ShowtimeId,
				BookingTime = DateTime.Now,
				TicketPrice = request.TicketPrice,
				Status = TicketStatus.Pending,
			};

			var ticket = _mapper.Map<Ticket>(ticketDto);
			await _context.Tickets.AddAsync(ticket);
			await _context.SaveChangesAsync();

			var seatIdsList = request.SeatIds
							  .Split(',')
							  .Select(int.Parse)
							  .ToList();

			foreach (var seatId in seatIdsList)
			{
				var ticketSeatAssignment = new TicketSeatAssignment
				{
					TicketId = ticket.TicketId,
					SeatId = seatId
				};
				await _context.TicketSeatAssignments.AddAsync(ticketSeatAssignment);

				var seat = await _context.Seats.FindAsync(seatId);
				if (seat != null)
				{
					seat.Status = (byte)SeatStatus.Unavailable;
					_context.Seats.Update(seat);
				}
			}

			// Add data to ShowtimeMovieAssignment table
			if (request.MovieId.HasValue && request.RoomId.HasValue)
			{
				var ticketMovieAssignment = new TicketMovieAssignment
				{
					TicketId = ticket.TicketId,
					MovieId = request.MovieId.Value,
					RoomId = request.RoomId.Value
				};

				await _context.TicketMovieAssignments.AddAsync(ticketMovieAssignment);
			}

			await _context.SaveChangesAsync();
			return ticket;
		}
	}
}
