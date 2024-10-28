using CinemaBooking.Data;

namespace CinemaBooking.Repositories.Theater;

public class TheaterRepository : BaseRepository<Data.Theater>, ITheaterRepository
{
    public TheaterRepository(CinemaBookingContext context) : base(context)
    {
    }
}