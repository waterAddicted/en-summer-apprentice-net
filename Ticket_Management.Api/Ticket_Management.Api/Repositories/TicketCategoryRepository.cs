using Ticket_Management.Api;
using Ticket_Management.Api.Models;
using Ticket_Management.Api.Repositories;
using TMS.Api.DbContext;
using TMS.Api.Repositories;

namespace Ticket_Management.Api.Repositories
{
    public class TicketCategoryRepository : BaseRepository<TicketCategory>, ITicketCategoryRepository
    {
        public TicketCategoryRepository(TicketManagementDbContext dbContext) : base(dbContext)
        {

        }
    }
}
