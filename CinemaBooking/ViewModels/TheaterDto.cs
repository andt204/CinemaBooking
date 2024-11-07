using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CinemaBooking.Enum;

namespace CinemaBooking.ViewModels
{
    public class TheaterDto
    {
        public int TheaterId { get; set; }

        [Required(ErrorMessage = "Theater name is required.")]
        [StringLength(100, ErrorMessage = "Theater name cannot exceed 100 characters.")]
        public string TheaterName { get; set; } = null!;

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(200, ErrorMessage = "Location cannot exceed 200 characters.")]
        public string? Location { get; set; }

        // Automatically set to Active when creating a new theater
        public TheaterStatus Status { get; set; } = TheaterStatus.Available;

        public List<ShowtimeDto> Showtimes { get; set; } = new List<ShowtimeDto>();
    }
}
