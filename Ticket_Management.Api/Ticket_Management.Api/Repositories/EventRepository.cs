using Ticket_Management.Api.Models;

namespace Ticket_Management.Api.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventsManagementContext _dbContext;

        public EventRepository()
        {
            _dbContext = new EventsManagementContext();
        }

        public int Add(Event @event)
        {
            throw new NotImplementedException();
        }

        public int Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events;

            return events;
        }

        public Event GetById(long id)
        {
            var @event = _dbContext.Events.Where(e => e.EventId == id).FirstOrDefault();

            return @event;
        }

        public void Update(Event @event)
        {
            throw new NotImplementedException();
        }
    }
}
