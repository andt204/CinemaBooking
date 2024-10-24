using AutoMapper;
using CinemaBooking.Data;
using CinemaBooking.ViewModels;
using System.Linq;
using System.Collections.Generic;

namespace CinemaBooking.AutoMapper {
	public class MovieProfile : Profile {
		public MovieProfile() {
			CreateMap<Movie, MovieDto>().ReverseMap();	
		}
	}
}
