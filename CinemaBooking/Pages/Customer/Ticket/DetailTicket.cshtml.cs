using CinemaBooking.Data;
using CinemaBooking.Repositories.Movie;
using CinemaBooking.Repositories.Room;
using CinemaBooking.Repositories.Seat;
using CinemaBooking.Repositories.Showtime;
using CinemaBooking.Repositories.Theater;
using CinemaBooking.Repositories.Ticket;
using CinemaBooking.Repositories.TicketMovie;
using CinemaBooking.Repositories.TicketPrice;
using CinemaBooking.Repositories.TicketSeat;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Customer.Ticket
{
    public class DetailTicketModel : PageModel
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IShowtimeRepository _showtimeRepository;
        private readonly ITicketMovieRepository _ticketMovieRepository;
        private readonly ITheaterRepository _theaterRepository;
        private readonly ITicketSeatRepository _ticketSeatRepository;
        public Data.Ticket Ticket { get; set; }
        public Data.Movie Movie { get; set; }
        public Data.Seat Seat { get; set; }
        public Data.Room Room { get; set; }
        public Data.Showtime Showtime { get; set; }
        public Data.TicketMovieAssignment TicketMovieAssignment  { get; set; }
        private Data.TicketSeatAssignment TicketSeatAssignment { get; set; }
        public Data.Theater Theater { get; set; }
        private DateTime BookingTime;
        public string Status { get; set; }
        private DateTime PublishTime;
        public string formattedBookingTime;
        public string formattedPublishTime;
        public DetailTicketModel(ITicketRepository ticketRepository, 
            IMovieRepository movieRepository, 
            ISeatRepository seatRepository,
            IRoomRepository roomRepository,
           IShowtimeRepository showtimeRepository,
            ITicketMovieRepository ticketMovieRepository,
            ITheaterRepository theaterRepository, 
            ITicketSeatRepository ticketSeatRepository
            )
        {
            _ticketRepository = ticketRepository;
            _movieRepository = movieRepository;
            _seatRepository = seatRepository;
            _roomRepository = roomRepository;
            _showtimeRepository = showtimeRepository;
            _ticketMovieRepository = ticketMovieRepository;
            _theaterRepository = theaterRepository;
            _ticketSeatRepository = ticketSeatRepository;
        }
        // public async Task OnGetAsync()
        // {
        //     Tickets = await _ticketRepository.GetListAsync();
        // }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Ticket = await _ticketRepository.GetByIdAsync(id);
            TicketMovieAssignment = await _ticketMovieRepository.GetByIdAsync(Ticket.TicketId);
            Movie = await _movieRepository.GetByIdAsync(TicketMovieAssignment.MovieId);
            //Room = await _roomRepository.GetByIdAsync(TicketMovieAssignment.RoomId);
            TicketSeatAssignment = await _ticketSeatRepository.GetByIdAsync(Ticket.TicketId);
            Seat = await _seatRepository.GetByIdAsync(TicketSeatAssignment.TicketSeatId);
            Showtime = await _showtimeRepository.GetByIdAsync(Ticket.ShowtimeId);
            //Theater = await _theaterRepository.GetByIdAsync(Showtime.TheaterId);
            BookingTime = Ticket.BookingTime;
             formattedBookingTime = BookingTime.ToString("HH:mm dd-MM-yyyy");
            if (Ticket.Status == 1)
            {
                Status = "Booked";
            }
            else
            {
                Status = "Not Booked";
            }
            
            PublishTime = Movie.PublishTime;
             formattedPublishTime = PublishTime.ToString("HH:mm dd-MM-yyyy");
             Showtime = await _showtimeRepository.GetByIdAsync(Ticket.ShowtimeId);
           //Theater = await _theaterRepository.GetByIdAsync(Showtime.TheaterId);
            return Page();
        }
    }
}
