using System;
using System.Collections.Generic;

namespace CinemaBooking.ViewModels
{
	public class ShowtimeDto
	{
		public int ShowtimeId { get; set; }
		public int TheaterId { get; set; }
		public int? RoomId { get; set; }
		public TimeSpan StartHour { get; set; }
		public DateTime Date { get; set; }

		// Add this property if you want to include movie assignments
		public List<ShowtimeMovieAssignmentDto> ShowtimeMovieAssignments { get; set; } = new List<ShowtimeMovieAssignmentDto>();
	}

	public class ShowtimeMovieAssignmentDto
	{
		public int ShowtimeMovieId { get; set; }
		public int MovieId { get; set; }
		// Add other properties as needed
	}
}
