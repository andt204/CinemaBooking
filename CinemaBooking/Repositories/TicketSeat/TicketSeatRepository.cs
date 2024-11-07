using CinemaBooking.Data;

namespace CinemaBooking.Repositories.TicketSeat;

public class TicketSeatRepository :BaseRepository<TicketSeatAssignment>, ITicketSeatRepository
{
    public TicketSeatRepository(CinemaBookingContext context) : base(context)
    {
    }
}