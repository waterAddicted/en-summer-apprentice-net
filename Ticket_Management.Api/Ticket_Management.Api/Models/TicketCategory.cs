using System;
using System.Collections.Generic;

namespace Ticket_Management.Api.Models;

public partial class TicketCategory
{
    public long TicketCategoryId { get; set; }

    public long? EventId { get; set; }

    public string? Description { get; set; }

    public int? Price { get; set; }

    public virtual Event? Event { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
