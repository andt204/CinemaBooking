using CinemaBooking.Data;
using CinemaBooking.ViewModels;
using Microsoft.EntityFrameworkCore;

public class MovieInteractionService
{
    private readonly CinemaBookingContext _context;

    public MovieInteractionService(CinemaBookingContext context)
    {
        _context = context;
    }

    public async Task<bool> AddVoteAsync(int movieId, int accountId, int rating)
    {
        try
        {
            var existingVote = await _context.Votes
                .FirstOrDefaultAsync(v => v.MovieId == movieId && v.AccountId == accountId);

            if (existingVote != null)
            {
                existingVote.Rating = rating;
                existingVote.VoteDate = DateTime.Now;
                _context.Votes.Update(existingVote);
            }
            else
            {
                var vote = new Vote
                {
                    MovieId = movieId,
                    AccountId = accountId,
                    Rating = rating,
                    VoteDate = DateTime.Now
                };
                await _context.Votes.AddAsync(vote);
            }

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> AddCommentAsync(int movieId, int accountId, string content, byte commentType)
    {
        try
        {
            var comment = new Comment
            {
                MovieId = movieId,
                AccountId = accountId,
                Content = content,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CommentType = commentType
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            
            return false;
        }
    }

    public async Task<double> GetMovieAverageRatingAsync(int movieId)
    {
        try
        {
            var average = await _context.Votes
                .Where(v => v.MovieId == movieId)
                .AverageAsync(v => (double?)v.Rating);

            return average ?? 0;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public async Task<List<CommentDto>> GetMovieCommentsAsync(int movieId)
    {
        try
        {
            return await _context.Comments
                .Where(c => c.MovieId == movieId)
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new CommentDto
                {
                    CommentId = c.CommentId,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt ?? DateTime.MinValue,
                    FullName = c.Account.FullName
                })
                .ToListAsync();
        }
        catch (Exception)
        {
            return new List<CommentDto>();
        }
    }
}