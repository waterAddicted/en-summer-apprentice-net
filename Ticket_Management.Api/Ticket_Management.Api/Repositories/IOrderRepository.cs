using Ticket_Management.Api.Models;

namespace Ticket_Management.Api.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();

        Task<Order> GetById(long id);

        int Add(Order @order);
        
        void Update(Order @order);

        void Delete(Order @order);

        IEnumerable<Order> GetAllSortedByDateAndPrice();
    }
}
