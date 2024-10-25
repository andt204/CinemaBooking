using CinemaBooking.Data;

namespace CinemaBooking.Repositories.TicketMovie;

public class TicketMovieRepository : BaseRepository<Data.TicketMovieAssignment>, ITicketMovieRepository
{
    public TicketMovieRepository(CinemaBookingContext context) : base(context)
    {
    }
}