using CinemaBooking.Data;
using CinemaBooking.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Pages.Customer.Movie
{
    public class ListModel : PageModel
    {
        private readonly CinemaBookingContext _context;
		[BindProperty]
		public Data.Account account { get; set; }
		public List<Data.Movie> NowShowingMovies { get; set; }
        public List<Data.Movie> ComingSoonMovies { get; set; }
        public List<Data.Movie> BannerMovies { get; set; }
        public List<string> TrailerVideoUrls { get; set; } = new List<string>();
        [BindProperty(SupportsGet = true)]
		public string? SearchTitle { get; set; }


		public ListModel(CinemaBookingContext context)
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

	        // Tìm kiếm phim theo tiêu đề và status = 1
	        var movies = _context.Movies.Where(m => m.Status == 1).AsQueryable(); // Thêm điều kiện status = 1

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

	        // Phân loại phim đang chiếu và sắp chiếu
	        NowShowingMovies = movieList.Where(m => m.PublishTime <= currentTime).ToList();
	        ComingSoonMovies = movieList.Where(m => m.PublishTime > currentTime).ToList();

	        // Lấy BannerMovies và TrailerVideoUrls 
	        BannerMovies = NowShowingMovies.OrderByDescending(m => m.PublishTime).Take(5).ToList();
	        BannerMovies.AddRange(ComingSoonMovies.OrderBy(m => m.PublishTime).Take(5));
	        TrailerVideoUrls = BannerMovies.Select(m => m.VideoTrailer).ToList();

	        return Page();
        }
    }
}
