using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int TicketId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal TotalPrice { get; set; }
        public byte Status { get; set; }

        public virtual Ticket Ticket { get; set; } = null!;
    }
}
