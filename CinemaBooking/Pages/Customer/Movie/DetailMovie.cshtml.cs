using CinemaBooking.Helper;
using CinemaBooking.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CinemaBooking.Pages.Customer.Movie
{
    [Authorize(Roles = "Customer")]
    public class DetailMovieModel : PageModel
    {
        private readonly CinemaBookingContext _context;
        private readonly MovieInteractionService _movieInteractionService;

        [BindProperty]
        public Data.Account account { get; set; }
        public Data.Movie Movie { get; set; }
        public List<CommentDto> Comments { get; set; }
        public double AverageRating { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Actor> Actors { get; set; } = new List<Actor>();
        public Director Director { get; set; }
        public bool HasUserRated { get; set; }
        public int? UserRating { get; set; }

        [BindProperty(SupportsGet = true)]
        public int MovieId { get; set; }

        [BindProperty]
        public int Rating { get; set; }

        [BindProperty]
        public string CommentContent { get; set; }

        [TempData]
        public string SuccessMessage { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public DetailMovieModel(CinemaBookingContext context, MovieInteractionService movieInteractionService)
        {
            _context = context;
            _movieInteractionService = movieInteractionService;
        }

        private async Task<int?> GetCurrentUserIdAsync()
        {
            var token = Request.Cookies["jwtToken"];
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

        private async Task LoadMovieData()
        {
            Movie = await _context.Movies
                .Include(m => m.MovieCategoryAssignments)
                .ThenInclude(mc => mc.Category)
                .Include(m => m.ActorMovieAssignments)
                .ThenInclude(am => am.Actor)
                .Include(m => m.Director)
                .FirstOrDefaultAsync(m => m.MovieId == MovieId);

            if (Movie != null)
            {
                var userId = await GetCurrentUserIdAsync();
                Comments = await _movieInteractionService.GetMovieCommentsAsync(MovieId);
                AverageRating = await _movieInteractionService.GetMovieAverageRatingAsync(MovieId);

                if (userId.HasValue)
                {
                    account = await _context.Accounts.FindAsync(userId.Value);
                    var existingVote = await _context.Votes
                        .FirstOrDefaultAsync(v => v.MovieId == MovieId && v.AccountId == userId.Value);

                    HasUserRated = existingVote != null;
                    UserRating = existingVote?.Rating;
                }

                Categories = Movie.MovieCategoryAssignments.Select(mc => mc.Category).ToList();
                Actors = Movie.ActorMovieAssignments.Select(am => am.Actor).ToList();
                Director = Movie.Director;
            }
        }

        public async Task<IActionResult> OnGetAsync(int movieId)
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
            MovieId = movieId;
            await LoadMovieData();
            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostSubmitReviewAsync()
        {
            MovieId = Int32.Parse(Request.Form["movieId"]);
            var userId = await GetCurrentUserIdAsync();

            if (!userId.HasValue)
            {
                return RedirectToPage("/Account/Login");
            }

            var hasErrors = false;

            // Xử lý Rating
            if (!string.IsNullOrEmpty(Request.Form["rating"]))
            {
                Rating = Int32.Parse(Request.Form["rating"]);
                if (Rating < 1 || Rating > 5)
                {
                    TempData["ErrorMessage"] = "Rating must be between 1 and 5.";
                    hasErrors = true;
                }
                else
                {
                    var ratingSuccess = await _movieInteractionService.AddVoteAsync(MovieId, userId.Value, Rating);
                    if (!ratingSuccess)
                    {
                        TempData["ErrorMessage"] = "Failed to submit rating.";
                        hasErrors = true;
                    }
                }
            }

            // Xử lý Comment
            CommentContent = Request.Form["CommentContent"].ToString();
            if (!string.IsNullOrWhiteSpace(CommentContent))
            {
                var commentSuccess = await _movieInteractionService.AddCommentAsync(MovieId, userId.Value, CommentContent, 1);
                if (!commentSuccess)
                {
                    TempData["ErrorMessage"] = string.IsNullOrEmpty(TempData["ErrorMessage"]?.ToString())
                        ? "Failed to post comment."
                        : TempData["ErrorMessage"] + " And failed to post comment.";
                    hasErrors = true;
                }
            }

            // Nếu cả hai đều thành công
            if (!hasErrors)
            {
                TempData["SuccessMessage"] = "Review submitted successfully!";
                CommentContent = string.Empty;
            }

            await LoadMovieData();
            return Page();
        }
    }
}