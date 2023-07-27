using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using Ticket_Management.Api.Models.DTOs;
using Ticket_Management.Api.Repositories;

namespace Ticket_Management.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public OrderController(IOrderRepository orderRepository, IMapper mapper, ILogger<OrderController> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _logger = logger;
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
        public async Task<ActionResult<OrderDto>> GetById(long id)
        {
            var @order = await _orderRepository.GetById(id);

            var orderDto = _mapper.Map<OrderDto>(@order);

            return Ok(orderDto);
        }


        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            var orderEntity = await _orderRepository.GetById(id);
            if (orderEntity == null)
            {
                return NotFound();
            }
            _orderRepository.Delete(orderEntity);
            return NoContent();
        }

        [HttpPatch]
        public async Task<ActionResult<OrderDto>> Patch(OrderDto orderPatch)
        {
            var orderEntity = await _orderRepository.GetById(orderPatch.OrderId);
            if (orderEntity == null)
            {
                return NotFound();
            }
            if (orderPatch.OrderAt.HasValue) orderEntity.OrderAt = orderPatch.OrderAt;
            if (orderPatch.NumberOfTickets.HasValue) orderEntity.NumberOfTickets = orderPatch.NumberOfTickets;
            if (orderPatch.TotalPrice.HasValue) orderEntity.TotalPrice = orderPatch.TotalPrice;
            _orderRepository.Update(orderEntity);
            return NoContent();
        }
    }
}
