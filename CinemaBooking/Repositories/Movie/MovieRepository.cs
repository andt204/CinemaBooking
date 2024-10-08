using CinemaBooking.Data;

namespace CinemaBooking.Repositories.Movie;

public class MovieRepository : BaseRepository<Data.Movie>, IMovieRepository
{
    public MovieRepository(CinemaBookingContext context) : base(context)
    {
    }
}