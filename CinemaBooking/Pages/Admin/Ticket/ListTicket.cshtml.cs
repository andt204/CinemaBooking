using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Admin.Ticket
{
    public class ListTicketModel : PageModel
    {
        private readonly AdminTicketService _adminTicketService;

        public List<AdminTicketDto> Tickets { get; set; }
        public List<string> Statuses { get; set; }
        public List<string> MovieNames { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MovieName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Status { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? FromDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? ToDate { get; set; }

        public ListTicketModel(AdminTicketService adminTicketService)
        {
            _adminTicketService = adminTicketService;
        }

        public async Task OnGetAsync()
        {
            Tickets = await _adminTicketService.GetAllTicketsAsync(MovieName, Status, FromDate, ToDate);
            Statuses = await _adminTicketService.GetAllStatusesAsync();
            MovieNames = await _adminTicketService.GetAllMovieNamesAsync();
        }
    }
}
