namespace Ticket_Management.Api.Models.DTOs
{
    public class OrderDto
    {
        public long OrderId { get; set; }

        public DateTime? OrderAt { get; set; }

        public int? NumberOfTickets { get; set; }

        public int? TotalPrice { get; set; }
    }
}
