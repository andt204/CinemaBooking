using CinemaBooking.Data;

namespace CinemaBooking.Repositories.Ticket;

public class TicketRepository : BaseRepository<Data.Ticket>, ITicketRepository
{
    public TicketRepository(CinemaBookingContext context) : base(context)
    {
    }
}