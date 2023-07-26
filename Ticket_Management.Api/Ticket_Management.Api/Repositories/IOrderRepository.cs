using Ticket_Management.Api.Models;

namespace Ticket_Management.Api.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();

        Order GetById(long id);

        int Add(Order @order);
        
        void Update(Order @order);

        int Delete(long id);

        IEnumerable<Order> GetAllSortedByDateAndPrice();
    }
}
