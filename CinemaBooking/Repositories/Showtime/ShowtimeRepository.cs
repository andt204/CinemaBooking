using CinemaBooking.Data;

namespace CinemaBooking.Repositories.Showtime;

public class ShowtimeRepository : BaseRepository<Data.Showtime>, IShowtimeRepository
{
    public ShowtimeRepository(CinemaBookingContext context) : base(context)
    {
    }
}