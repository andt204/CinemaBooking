using CinemaBooking.Data;

namespace CinemaBooking.Repositories.Post;

public class PostRepository : BaseRepository<Data.Post>, IPostRepository
{
    public PostRepository(CinemaBookingContext context) : base(context)
    {
        
    }
}