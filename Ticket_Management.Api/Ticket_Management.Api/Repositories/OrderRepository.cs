using Ticket_Management.Api.Models;

namespace Ticket_Management.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EventsManagementContext _dbContext;

        public OrderRepository()
        {
            _dbContext = new EventsManagementContext();
        }

        public int Add(Order @order)
        {
            throw new NotImplementedException();
        }

        public int Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders;

            return orders;
        }

        public Order GetById(long id)
        {
            var @order = _dbContext.Orders.Where(e => e.OrderId == id).FirstOrDefault();

            return @order;
        }

        public void Update(Order @order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllSortedByDateAndPrice()
        {
            var orders = _dbContext.Orders;

            var orderSorted_by_date = orders.OrderBy(e => e.OrderAt);
            return orderSorted_by_date.OrderBy(e => e.TotalPrice);
        }
    }
}
