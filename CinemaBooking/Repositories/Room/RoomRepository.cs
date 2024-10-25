using CinemaBooking.Data;

namespace CinemaBooking.Repositories.Room;

public class RoomRepository : BaseRepository<Data.Room> , IRoomRepository
{
    public RoomRepository(CinemaBookingContext context) : base(context)
    {
    }
}