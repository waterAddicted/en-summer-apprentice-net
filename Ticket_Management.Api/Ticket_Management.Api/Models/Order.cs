using System;
using System.Collections.Generic;

namespace Ticket_Management.Api.Models;

public partial class Order
{
    public long OrderId { get; set; }

    public long? UserId { get; set; }

    public long? TicketCategoryId { get; set; }

    public DateTime? OrderAt { get; set; }

    public int? NumberOfTickets { get; set; }

    public int? TotalPrice { get; set; }

    public virtual TicketCategory? TicketCategory { get; set; }

    public virtual User? User { get; set; }
}
