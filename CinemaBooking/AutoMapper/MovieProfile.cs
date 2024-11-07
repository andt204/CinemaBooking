using AutoMapper;
using CinemaBooking.ViewModels;
using System.Linq;
using System.Collections.Generic;
using CinemaBooking.Data;

namespace CinemaBooking.AutoMapper
{
    public class MovieProfile : Profile {
		public MovieProfile() {
			CreateMap<Movie, MovieDto>().ReverseMap();	
		}
	}
}
