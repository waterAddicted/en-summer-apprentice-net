﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ticket_Management.Api.Exceptions;
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

        public void Delete(Order @order)
        {
            _dbContext.Remove(order);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _dbContext.Orders;

            return orders;
        }

        public async Task<Order> GetById(long id)
        {
            var @order = await _dbContext.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();

            if (@order == null)
                throw new EntityNotFoundException(id, nameof(Order));

            return @order;
        }


        public void Update(Order @order)
        {
            _dbContext.Entry(@order).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAllSortedByDateAndPrice()
        {
            var orders = _dbContext.Orders;

            var orderSorted_by_date = orders.OrderBy(o => o.OrderAt).ThenBy(o=>o.TotalPrice);
            return orderSorted_by_date;

        }
    }
}
