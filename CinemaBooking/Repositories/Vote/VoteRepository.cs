using CinemaBooking.Data;

namespace CinemaBooking.Repositories.Vote;

public class VoteRepository : BaseRepository<Data.Vote>, IVoteRepository
{
    public VoteRepository(CinemaBookingContext context) : base(context)
    {
        
    }
}