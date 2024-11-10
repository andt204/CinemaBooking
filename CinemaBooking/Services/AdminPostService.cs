using CinemaBooking.Data;
using CinemaBooking.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Services
{
    public class AdminPostService
    {
        private readonly CinemaBookingContext _context;

        public AdminPostService(CinemaBookingContext context)
        {
            _context = context;
        }

        public async Task<List<PostDto>> GetAllPostsAsync(
            string title = "",
            string status = "",
            DateTime? fromDate = null,
            DateTime? toDate = null)
        {
            var query = _context.Posts
                .Include(p => p.Account)
                .AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(p => p.Title.Contains(title));
            }

            if (!string.IsNullOrEmpty(status))
            {
                var statusValue = status == "Active" ? (byte)1 : (byte)0;
                query = query.Where(p => p.Status == statusValue);
            }

            if (fromDate.HasValue)
            {
                query = query.Where(p => p.CreatedDate.Date >= fromDate.Value.Date);
            }

            if (toDate.HasValue)
            {
                query = query.Where(p => p.CreatedDate.Date <= toDate.Value.Date);
            }

            return await query
                .Select(p => new PostDto
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Content = p.Content,
                    CreatedDate = p.CreatedDate,
                    ModifiedDate = p.ModifiedDate,
                    AuthorName = p.Account.FullName,
                    Status = p.Status
                })
                .OrderByDescending(p => p.CreatedDate)
                .ToListAsync();
        }

        public async Task<bool> HidePostAsync(int postId)
        {
            try
            {
                var post = await _context.Posts.FindAsync(postId);
                if (post == null) return false;

                post.Status = 0; // 0 for hidden
                post.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}