using AutoMapper;
using CinemaBooking.Data;
using CinemaBooking.ViewModels;

namespace CinemaBooking.AutoMapper {
	public class ShowtimeProfile : Profile {
		public ShowtimeProfile() {
			CreateMap<Showtime, ShowtimeDto>().ReverseMap();
		}
	}
}
