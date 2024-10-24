using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemaBooking.Data; 
using CinemaBooking.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Services
{
	public class CinemaSelectionService
	{
		private readonly CinemaBookingContext _context;
		private readonly IMapper _mapper;

		public CinemaSelectionService(CinemaBookingContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<MovieDto> GetMovieByIdAsync(int movieId)
		{
			var movie = await _context.Movies
				.Include(m => m.Director)
				.Include(m => m.MovieCategoryAssignments)
					.ThenInclude(mca => mca.Category)
				.Include(m => m.ActorMovieAssignments)
					.ThenInclude(ama => ama.Actor)
				.FirstOrDefaultAsync(m => m.MovieId == movieId);

			var movieDto = _mapper.Map<MovieDto>(movie);

			movieDto.Categories = movie.MovieCategoryAssignments != null
						? movie.MovieCategoryAssignments.Select(mca => mca.Category != null ? mca.Category.CategoryName : "Unknown").ToList()
						: new List<string>();
			movieDto.Actors = movie.ActorMovieAssignments != null
						? movie.ActorMovieAssignments.Select(ama => ama.Actor != null ? ama.Actor.ActorName : "Unknown").ToList()
						: new List<string>();
			movieDto.DirectorName = movie.Director != null ? movie.Director.DirectorName : "Unknown";

			return movieDto;
		}

		public async Task<List<TheaterDto>> GetListTheaterAsync(int movieId)
		{
			var theaters = await _context.Theaters
				.Include(t => t.Showtimes) // Include showtimes for each theater
					.ThenInclude(s => s.ShowtimeMovieAssignments) // Include movie assignments for each showtime
				.ToListAsync();

			var theaterDtos = _mapper.Map<List<TheaterDto>>(theaters);

			// Filter theaters that have showtimes with the specified movieId
			return theaterDtos
				.Where(t => t.Showtimes.Any(s => s.ShowtimeMovieAssignments.Any(sma => sma.MovieId == movieId))
				).ToList();
		}

	}
}
