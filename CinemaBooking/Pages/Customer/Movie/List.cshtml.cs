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

        public ListModel(CinemaBookingContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            var currentTime = DateTime.Now;

            var movies = await _context.Movies
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
            NowShowingMovies = movies.Where(m => m.PublishTime <= currentTime).ToList();
            ComingSoonMovies = movies.Where(m => m.PublishTime > currentTime).ToList();

            // Lấy 5 phim đang chiếu mới nhất
            var recentMovies = NowShowingMovies.OrderByDescending(m => m.PublishTime).Take(5).ToList();

            // Lấy 5 phim sắp chiếu sớm nhất
            var upcomingMovies = ComingSoonMovies.OrderBy(m => m.PublishTime).Take(5).ToList();

            // Lấy URL của trailer cho những phim này
            TrailerVideoUrls = recentMovies.Select(m => m.VideoTrailer).Concat(upcomingMovies.Select(m => m.VideoTrailer)).ToList();

            // Lấy danh sách phim để hiển thị hình ảnh nền
            BannerMovies = recentMovies.Concat(upcomingMovies).ToList();
			
			var token = Request.Cookies["jwtToken"];
			if (token != null) {
				var email = DecodeJwtToken.DecodeJwtTokenAndGetEmail(token);
				if (email != null) {
					account = _context.Accounts.FirstOrDefault(x => x.Email == email);
					ViewData["Account"] = account; // Truyền dữ liệu account vào ViewData
				}
			}
		}
    }
}
