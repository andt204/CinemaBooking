using AutoMapper;
using CinemaBooking.Data;
using CinemaBooking.ViewModels;

namespace CinemaBooking.AutoMapper
{
	public class ShowtimeMovieAssignmentProfile : Profile
	{
		public ShowtimeMovieAssignmentProfile()
		{
			CreateMap<ShowtimeMovieAssignment, ShowtimeMovieAssignmentDto>()
				.ReverseMap(); 
		}
	}
}
