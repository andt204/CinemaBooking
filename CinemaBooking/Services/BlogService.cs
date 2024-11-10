using CinemaBooking.Data;
using CinemaBooking.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Services
{
    public class BlogService
    {
        private readonly CinemaBookingContext _context;

        public BlogService(CinemaBookingContext context)
        {
            _context = context;
        }

        public async Task<List<PostDto>> GetAllPostsAsync()
        {
            return await _context.Posts
                .Include(p => p.Account)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.Account)
                .Where(p => p.Status == 1)
                .OrderByDescending(p => p.CreatedDate)
                .Select(p => new PostDto
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Content = p.Content,
                    CreatedDate = p.CreatedDate,
                    ModifiedDate = p.ModifiedDate,
                    AccountId = p.AccountId,
                    AuthorName = p.Account.FullName,
                    Status = p.Status,
                    Comments = p.Comments
                        .Where(c => c.CommentType == 2)
                        .Select(c => new BlogCommentDto
                        {
                            CommentId = c.CommentId,
                            PostId = c.PostId,
                            AccountId = c.AccountId,
                            Content = c.Content,
                            CreatedAt = c.CreatedAt ?? DateTime.MinValue,
                            UpdatedAt = c.UpdatedAt,
                            FullName = c.Account.FullName,
                            Status = c.Status,
                            CommentType = c.CommentType
                        }).ToList()
                })
                .ToListAsync();
        }

        public async Task<bool> CreatePostAsync(CreatePostDto postDto)
        {
            try
            {
                var post = new Post
                {
                    Title = postDto.Title,
                    Content = postDto.Content,
                    AccountId = postDto.AccountId,
                    CreatedDate = DateTime.Now,
                    Status = 1
                };

                await _context.Posts.AddAsync(post);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddCommentAsync(int postId, int accountId, string content)
        {
            try
            {
                var comment = new Comment
                {
                    PostId = postId,
                    AccountId = accountId,
                    Content = content,
                    CreatedAt = DateTime.Now,
                    Status = 1,
                    CommentType = 2 // Blog comment type
                };

                await _context.Comments.AddAsync(comment);
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