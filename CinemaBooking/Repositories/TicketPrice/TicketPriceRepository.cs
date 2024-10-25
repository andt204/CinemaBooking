using CinemaBooking.Data;

namespace CinemaBooking.Repositories.TicketPrice;

public class TicketPriceRepository : BaseRepository<Data.TicketPrice>, ITicketPriceRepository
{
    public TicketPriceRepository(CinemaBookingContext context) : base(context)
    {
    }
}