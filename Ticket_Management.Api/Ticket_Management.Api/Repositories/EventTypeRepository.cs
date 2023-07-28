using Ticket_Management.Api.Models;
using Ticket_Management.Api.Repositories;
using TMS.Api.DbContext;

namespace TMS.Api.Repositories
{
    public class EventTypeRepository : BaseRepository<EventType>, IEventTypeRepository
    {
        public EventTypeRepository(TicketManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
