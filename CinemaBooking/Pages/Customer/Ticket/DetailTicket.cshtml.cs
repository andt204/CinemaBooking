using CinemaBooking.Data;
using CinemaBooking.Repositories.Movie;
using CinemaBooking.Repositories.Room;
using CinemaBooking.Repositories.Seat;
using CinemaBooking.Repositories.Showtime;
using CinemaBooking.Repositories.Ticket;
using CinemaBooking.Repositories.TicketMovie;
using CinemaBooking.Repositories.TicketPrice;
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
        
        public Data.Ticket Ticket { get; set; }
        public Data.Movie Movie { get; set; }
        public Data.Seat Seat { get; set; }
        public Data.Room Room { get; set; }
        public Data.Showtime Showtime { get; set; }
        public Data.TicketMovieAssignment TicketMovieAssignment  { get; set; }
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
            ITicketMovieRepository ticketMovieRepository
            )
        {
            _ticketRepository = ticketRepository;
            _movieRepository = movieRepository;
            _seatRepository = seatRepository;
            _roomRepository = roomRepository;
            _showtimeRepository = showtimeRepository;
            _ticketMovieRepository = ticketMovieRepository;
        }
        // public async Task OnGetAsync()
        // {
        //     Tickets = await _ticketRepository.GetListAsync();
        // }
        public async Task<IActionResult> OnGetAsync(int id)
        {
           var ticket = await _ticketRepository.GetByIdAsync(id);
           var ticketMovie = await _ticketMovieRepository.GetByIdAsync(ticket.TicketId);
           Movie = await _movieRepository.GetByIdAsync(ticketMovie.MovieId);
           // Seat = await _seatRepository.GetByIdAsync(ticket.SeatId);
           // TicketPrice = await _ticketPriceRepository.GetByIdAsync(ticket.PriceId); 
           Room = await _roomRepository.GetByIdAsync(ticketMovie.RoomId);
            BookingTime = ticket.BookingTime;
             formattedBookingTime = BookingTime.ToString("HH:mm dd-MM-yyyy");
            if (ticket.Status == 1)
            {
                Status = "Booked";
            }
            else
            {
                Status = "Not Booked";
            }
            
            PublishTime = Movie.PublishTime;
             formattedPublishTime = PublishTime.ToString("HH:mm dd-MM-yyyy");
           // Showtime = await _showtimeRepository.GetByIdAsync(Showtime.ShowtimeId);
        
            return Page();
        }
    }
}
