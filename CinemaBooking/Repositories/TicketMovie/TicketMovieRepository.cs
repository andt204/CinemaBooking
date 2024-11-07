using CinemaBooking.Data;

namespace CinemaBooking.Repositories.TicketMovie;

public class TicketMovieRepository : BaseRepository<TicketMovieAssignment>, ITicketMovieRepository
{
    public TicketMovieRepository(CinemaBookingContext context) : base(context)
    {
    }
}