using CinemaBooking.Data;
using CinemaBooking.Helper;
using CinemaBooking.Services;
using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Pages.Customer.Blog
{
    public class BlogModel : PageModel
    {
        [BindProperty]
        public Data.Account account { get; set; }
        private readonly CinemaBookingContext _context;
        private readonly BlogService _blogService;
        private readonly IConfiguration _configuration;

        public List<PostDto> Posts { get; set; }
        public Data.Account Account { get; set; }

        [BindProperty]
        public CreatePostDto NewPost { get; set; }

        [BindProperty]
        public string CommentContent { get; set; }

        [TempData]
        public string SuccessMessage { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public BlogModel(CinemaBookingContext context, BlogService blogService, IConfiguration configuration)
        {
            _context = context;
            _blogService = blogService;
            _configuration = configuration;
        }

        private async Task<int?> GetCurrentUserIdAsync()
        {


            var token = Request.Cookies["jwtToken"];
            if (token != null)
            {
                var email = DecodeJwtToken.DecodeJwtTokenAndGetEmail(token);
                if (email != null)
                {
                    account = _context.Accounts.FirstOrDefault(x => x.AccountId == Int32.Parse(email));
                    ViewData["Account"] = account; // Truyền dữ liệu account vào ViewData
                }
            }
         
            if (string.IsNullOrEmpty(token))
            {
                return null;
            }

            var accountIdStr = DecodeJwtToken.DecodeJwtTokenAndGetEmail(token);
            if (int.TryParse(accountIdStr, out int accountId))
            {
                return accountId;
            }
            return null;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Posts = await _blogService.GetAllPostsAsync();

            var userId = await GetCurrentUserIdAsync();
            if (userId.HasValue)
            {
                Account = await _context.Accounts.FindAsync(userId.Value);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            var userId = await GetCurrentUserIdAsync();
            if (!userId.HasValue)
            {
                return RedirectToPage("/Account/Login");
            }

            if (string.IsNullOrWhiteSpace(NewPost.Content))
            {
                TempData["ErrorMessage"] = "Post content cannot be empty.";
                return RedirectToPage();
            }

            NewPost.AccountId = userId.Value;
            var success = await _blogService.CreatePostAsync(NewPost);

            if (success)
            {
                TempData["SuccessMessage"] = "Post created successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to create post.";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCommentAsync(int postId)
        {
            var userId = await GetCurrentUserIdAsync();
            if (!userId.HasValue)
            {
                return RedirectToPage("/Account/Login");
            }

            if (string.IsNullOrWhiteSpace(CommentContent))
            {
                TempData["ErrorMessage"] = "Comment content cannot be empty.";
                return RedirectToPage();
            }

            var success = await _blogService.AddCommentAsync(postId, userId.Value, CommentContent);
            if (success)
            {
                TempData["SuccessMessage"] = "Comment posted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to post comment.";
            }

            return RedirectToPage();
        }
    }
}