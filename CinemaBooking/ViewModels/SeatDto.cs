using CinemaBooking.Data;
using CinemaBooking.Enum;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.ViewModels
{
    public class SeatDto
    {
        public int SeatId { get; set; }

        [Required(ErrorMessage = "Seat Type is required.")]
        public int SeatTypeId { get; set; }

        [Required(ErrorMessage = "Room ID is required.")]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Row is required.")]
        [RegularExpression("^[a-zA-Z]$", ErrorMessage = "Row must be a single letter (A-Z or a-z).")]
        public string Row { get; set; }

        [Required(ErrorMessage = "Column is required.")]
        [Range(1, 30, ErrorMessage = "Column must be between 1 and 30.")]
        public int Column { get; set; }

        [Required(ErrorMessage = "Seat status is required.")]
        public SeatStatus Status { get; set; }

        [ValidateNever]
        public SeatTypeDto SeatType { get; set; } = null!;

        [ValidateNever]
        public RoomDto Room { get; set; } = null!;
    }
}
