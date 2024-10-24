namespace CinemaBooking.ViewModels {
	public class TheaterDto {
		public int TheaterId { get; set; }
		public string TheaterName { get; set; } = null!;
		public string? Location { get; set; }
		public List<ShowtimeDto> Showtimes { get; set; } = new List<ShowtimeDto>();
	}
}
