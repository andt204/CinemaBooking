using CinemaBooking.Data;
using System.Collections.Generic;

namespace CinemaBooking.ViewModels
{
	public class RoomDto
	{
		public int RoomId { get; set; }
		public int RoomTypeId { get; set; }
		public string RoomName { get; set; } = null!;
		public byte Status { get; set; }
		public RoomTypeDto RoomType { get; set; } = null!;
        public List<SeatDto> Seats { get; set; }
    }
}
