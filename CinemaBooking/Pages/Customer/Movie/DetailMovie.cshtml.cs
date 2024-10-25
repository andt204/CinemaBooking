using CinemaBooking.Data;
using CinemaBooking.Helper;
using CinemaBooking.Repositories;
using CinemaBooking.Repositories.Movie;
using CinemaBooking.Repositories.Post;
using CinemaBooking.Repositories.Vote;
using CinemaBooking.Repositories.Comment;

using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace CinemaBooking.Pages.Customer.Movie
{
	public class DetailMovieModel : PageModel
	{
		private readonly CinemaBookingContext _context;
        private readonly IVoteRepository _voteRepository;
        private readonly ICommentRepository _commentRepository;

        public Data.Account account { get; set; }
        public DetailMovieModel(CinemaBookingContext context, ICommentRepository commentRepository, IVoteRepository voteRepository)
		{
			_context = context;
            _commentRepository = commentRepository;
            _voteRepository = voteRepository;
		}

		public Data.Movie Movie { get; set; }
		public List<Showtime> Showtimes { get; set; } = new List<Showtime>(); // List to hold showtimes
		public List<Category> Categories { get; set; } = new List<Category>(); // List to hold categories
        public List<Actor> Actors { get; set; } = new List<Actor>(); // List to hold actors
        public Director Director { get; set; } // To hold director information

        public List<VoteDto> Votes { get; set; } = new List<VoteDto>();
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
        [BindProperty]
        public int Rating { get; set; }

        [BindProperty]
        public string CommentContent { get; set; }

        public async Task<IActionResult> OnGetAsync(int movieId) // Using movieId as the parameter
		{
            // Fetch the movie details
            var token = Request.Cookies["jwtToken"];
            if (token != null)
            {
                var email = DecodeJwtToken.DecodeJwtTokenAndGetEmail(token);
                if (email != null)
                {
                    account = _context.Accounts.FirstOrDefault(x => x.AccountId == Int32.Parse(email));
                    ViewData["Account"] = account; // Pass account data to ViewData
                }
            }
            Movie = await _context.Movies.FindAsync(movieId);

			if (Movie == null)
			{
				return NotFound(); // Return 404 if movie not found
			}

			// Fetch showtimes associated with the movie using the ShowtimeMovieAssignments
			Showtimes = await _context.ShowtimeMovieAssignments
				.Where(s => s.MovieId == movieId) // Get assignments for the specific movie
				.Select(s => s.Showtime) // Get the related showtime
				.ToListAsync();

			Categories = await _context.MovieCategoryAssignments
				.Where(mc => mc.MovieId == movieId) // Get assignments for the specific movie
				.Select(mc => mc.Category) // Get the related category
				.ToListAsync();

            Actors = await _context.ActorMovieAssignments
                .Where(am => am.MovieId == movieId)
                .Select(am => am.Actor)
                .ToListAsync();

           Director = await _context.Directors
                .Where(d => d.DirectorId == Movie.DirectorId)
                .FirstOrDefaultAsync();

            // Fetch votes and comments
            Votes = await _context.Votes
                .Where(v => v.MovieId == movieId)
                .Select(v => new VoteDto
                {
                    VoteId = v.VoteId,
                    Rating = v.Rating,
                    FullName = v.Account.FullName,
                    VoteDate = v.VoteDate
                }).ToListAsync();
            double averageRating = 0;
            if (Votes.Any())
            {
                averageRating = Votes.Average(v => v.Rating);
            }
            ViewData["AverageRating"] = averageRating;

            Comments = await _context.Comments
                .Where(c => c.MovieId == movieId)
                .Select(c => new CommentDto
                {
                    CommentId = c.CommentId,
                    Content = c.Content,
                    FullName = c.Account.FullName,
                    CreatedAt = c.CreatedAt
                }).ToListAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostRateAsync(int movieId)
        {
            if (account == null)
            {
                return RedirectToPage("/Account/Login");
            }

            var vote = new Vote
            {
                MovieId = movieId,
                AccountId = account.AccountId,
                Rating = Rating,
                VoteDate = DateTime.UtcNow
            };
            await _voteRepository.CreateAsync(vote);
            
            return RedirectToPage(new { movieId });
        }


        // Phương thức để lưu comment
        public async Task<IActionResult> OnPostCommentAsync(int movieId)
        {
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(CommentContent))
            {
                var comment = new Comment
                {
                    MovieId = movieId,
                    AccountId = account.AccountId,
                    Content = CommentContent,
                    CreatedAt = DateTime.UtcNow
                };
                await _commentRepository.CreateAsync(comment);
        }

            return RedirectToPage(new { movieId
    });
        }
    }

}

