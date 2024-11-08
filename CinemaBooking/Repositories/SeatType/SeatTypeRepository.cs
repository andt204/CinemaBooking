using CinemaBooking.Data;

namespace CinemaBooking.Repositories.SeatType;

public class SeatTypeRepository : BaseRepository<Data.SeatType>, ISeatTypeRepository
{
    public SeatTypeRepository(CinemaBookingContext context) : base(context)
    {
    }
}