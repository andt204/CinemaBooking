using CinemaBooking.Data;

namespace CinemaBooking.Repositories.Seat;

public class SeatRepository : BaseRepository<Data.Seat>, ISeatRepository
{
    public SeatRepository(CinemaBookingContext context) : base(context)
    {
    }
}