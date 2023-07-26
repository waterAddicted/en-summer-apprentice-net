using Microsoft.AspNetCore.Mvc;
using Ticket_Management.Api.Models.DTOs;
using Ticket_Management.Api.Repositories;

namespace Ticket_Management.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAll()
        {
            var orders = _orderRepository.GetAll();

            var dtoOrders = orders.Select(e => new OrderDto()
            {
                OrderId = e.OrderId,
                OrderAt = e.OrderAt,
                NumberOfTickets = e.NumberOfTickets,
                TotalPrice = e.TotalPrice
            });


            return Ok(dtoOrders);
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAllSortedByDateAndPrice()
        {
            var orders = _orderRepository.GetAllSortedByDateAndPrice();

            var dtoOrders = orders.Select(e => new OrderDto()
            {
                OrderId = e.OrderId,
                OrderAt = e.OrderAt,
                NumberOfTickets = e.NumberOfTickets,
                TotalPrice = e.TotalPrice
            });


            return Ok(dtoOrders);
        }


        [HttpGet]
        public ActionResult<OrderDto> GetById(long id)
        {
            var @order = _orderRepository.GetById(id);

            if (@order == null)
            {
                return NotFound();
            }

            var dtoOrder = new OrderDto()
            {
                OrderId = @order.OrderId,
                OrderAt = @order.OrderAt,
                NumberOfTickets = @order.NumberOfTickets,
                TotalPrice = @order.TotalPrice,
            };

            return Ok(dtoOrder);
        }
    }
}
