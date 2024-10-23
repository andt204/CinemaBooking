using CinemaBooking.Data;

namespace CinemaBooking.ViewModels
{
    public class MovieDto
    {
        public string Title { get; set; } = null!;
        public int Length { get; set; }
        public string? Description { get; set; }
        public int AgeLimit { get; set; }
        public string? WarningText { get; set; }
        public DateTime PublishTime { get; set; }
        public string? Country { get; set; }
        public string? Image { get; set; }
        public string? ImageBackground { get; set; }
        public byte Status { get; set; }
        public string DirectorName { get; set; }
        public string VideoTrailer { get; set; } = null!;
        public List<string> Categories { get; set; }
        public List<string> Actors { get; set; }
    }
}
