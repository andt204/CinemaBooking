using CinemaBooking.Data;

namespace CinemaBooking.Repositories.Role;

public class RoleRepository : BaseRepository<Data.Role>, IRoleRepository
{
    public RoleRepository(CinemaBookingContext context) : base(context)
    {
    }
}