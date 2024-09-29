using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class TicketPrice
    {
        public TicketPrice()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int TicketPriceId { get; set; }
        public decimal TicketPrice1 { get; set; }
        public byte Status { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
