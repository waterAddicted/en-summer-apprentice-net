using Ticket_Management.Api.Models;

namespace Ticket_Management.Api.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();

        Event GetById(long id);

        int Add(Event @event);

        void Update(Event @event);

        int Delete(long id);

        Event GetByName(string name);


    }
}
