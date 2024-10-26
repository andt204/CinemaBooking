using CinemaBooking.Data;
using CinemaBooking.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Pages.Customer.Movie
{
    public class ComingSoonModel : PageModel
    {
        private readonly CinemaBookingContext _context;
        [BindProperty]
        public Data.Account account { get; set; }
        public List<Data.Movie> ComingSoonMovies { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchTitle { get; set; }


        public ComingSoonModel(CinemaBookingContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(string? searchTitle)
        {
            Console.WriteLine($"SearchTitle: {searchTitle}");
            SearchTitle = searchTitle;
            var currentTime = DateTime.Now;
            var token = Request.Cookies["jwtToken"];
            if (token != null)
            {
                var email = DecodeJwtToken.DecodeJwtTokenAndGetEmail(token);
                if (email != null)
                {
                    account = _context.Accounts.FirstOrDefault(x => x.AccountId == Int32.Parse(email));
                    ViewData["Account"] = account; 
                }
            }
            var movies = _context.Movies.AsQueryable();
            if (!string.IsNullOrEmpty(SearchTitle))
            {
                movies = movies.Where(m => m.Title.Contains(SearchTitle));
            }

            var movieList = await movies
                .Select(m => new Data.Movie
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    Length = m.Length,
                    Description = m.Description,
                    AgeLimit = m.AgeLimit,
                    PublishTime = m.PublishTime,
                    Country = m.Country,
                    Image = m.Image,
                    Status = m.Status,
                    VideoTrailer = m.VideoTrailer,
                    ImageBackground = m.ImageBackground
                }).ToListAsync();

            ComingSoonMovies = movieList.Where(m => m.PublishTime > currentTime & m.Status == 1).ToList();
            return Page();
        }
    }
}
