using CinemaBooking.Data;

namespace CinemaBooking.Repositories.TicketSeat;

public class TicketSeatRepository :BaseRepository<Data.TicketSeatAssignment>, ITicketSeatRepository
{
    public TicketSeatRepository(CinemaBookingContext context) : base(context)
    {
    }
}