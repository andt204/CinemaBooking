using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaBooking.Data; // Đảm bảo namespace đúng cho DbContext và các mô hình
using CinemaBooking.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Services {
    public class CinemaSelectionService {
        private readonly CinemaBookingContext _context;

        public CinemaSelectionService(CinemaBookingContext context) {
            _context = context;
        }

		public async Task<MovieDto> GetMovieByIdAsync(int movieId) {
			// Truy vấn thông tin phim theo movieId từ cơ sở dữ liệu
			return await _context.Movies
				.Where(m => m.MovieId == movieId) // Lọc phim theo movieId
				.Include(m => m.Director) // Bao gồm thông tin đạo diễn
				.Include(m => m.MovieCategoryAssignments)
					.ThenInclude(mca => mca.Category) // Bao gồm thông tin thể loại
				.Include(m => m.ActorMovieAssignments)
					.ThenInclude(ama => ama.Actor) // Bao gồm thông tin diễn viên
				.Select(movie => new MovieDto {
					Title = movie.Title,
					PublishTime = movie.PublishTime,
					Length = movie.Length, // Lưu độ dài phim tính bằng phút
					DirectorName = movie.Director != null ? movie.Director.DirectorName : "Unknown", // Kiểm tra đạo diễn
					Country = movie.Country,
					Categories = movie.MovieCategoryAssignments != null
						? movie.MovieCategoryAssignments.Select(mca => mca.Category != null ? mca.Category.CategoryName : "Unknown").ToList()
						: new List<string>(), // Kiểm tra thể loại
					Actors = movie.ActorMovieAssignments != null
						? movie.ActorMovieAssignments.Select(ama => ama.Actor != null ? ama.Actor.ActorName : "Unknown").ToList()
						: new List<string>(), // Kiểm tra diễn viên
					Image = movie.Image // Giả sử bạn có thuộc tính này trong bảng phim
				})
				.FirstOrDefaultAsync(); // Lấy phim đầu tiên hoặc null nếu không tìm thấy
		}

	}
}
