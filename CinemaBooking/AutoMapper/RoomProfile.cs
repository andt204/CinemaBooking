using AutoMapper;
using CinemaBooking.Data;
using CinemaBooking.ViewModels;

namespace CinemaBooking.AutoMapper
{
	public class RoomProfile : Profile
	{
		public RoomProfile()
		{
			CreateMap<Room, RoomDto>().ReverseMap();
			CreateMap<RoomType, RoomTypeDto>().ReverseMap();
		}
	}
}
