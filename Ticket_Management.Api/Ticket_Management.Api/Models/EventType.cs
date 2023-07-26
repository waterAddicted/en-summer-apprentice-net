using System;
using System.Collections.Generic;

namespace Ticket_Management.Api.Models;

public partial class EventType
{
    public long EventtypeId { get; set; }

    public string? EventTypeName { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
