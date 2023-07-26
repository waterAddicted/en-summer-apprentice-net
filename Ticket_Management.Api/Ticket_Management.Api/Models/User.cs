using System;
using System.Collections.Generic;

namespace Ticket_Management.Api.Models;

public partial class User
{
    public long UserId { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
