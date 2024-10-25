using CinemaBooking.Data;

namespace CinemaBooking.Repositories.Comment;

public class CommentRepository : BaseRepository<Data.Comment>, ICommentRepository
{
    public CommentRepository(CinemaBookingContext context) : base(context)
    {
        
    }
}