using Xunit;
using Ticket_Management.Api.Controllers;
using Ticket_Management.Api.Models;
using Ticket_Management.Api.Repositories;
using Ticket_Management.Api.Models.DTOs;
using AutoMapper;
using Microsoft;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;
using Assert = Xunit.Assert;
using Microsoft.AspNetCore.Mvc;

namespace Ticket_Management.UnitTests;
[TestClass]
public class OrderControllerTests
{

    [TestMethod]
    public void GetAll_Should_Return_All_Orders()
    {
        // Arrange
        var orders = new List<Order>
        {
            new Order { OrderId = 1, OrderAt = DateTime.Now, NumberOfTickets = 3, TotalPrice = 100 },
            new Order { OrderId = 2, OrderAt = DateTime.Now, NumberOfTickets = 2, TotalPrice = 50 }
        };

        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(repo => repo.GetAll()).Returns(orders);

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(mapper => mapper.Map<OrderDto>(It.IsAny<Order>())).Returns((Order order) => new OrderDto
        {
            OrderId = order.OrderId,
            OrderAt = order.OrderAt,
            NumberOfTickets = order.NumberOfTickets,
            TotalPrice = order.TotalPrice
        });

        var mockLogger = new Mock<ILogger<OrderController>>();

        var controller = new OrderController(mockOrderRepository.Object, mockMapper.Object, mockLogger.Object);

        // Act
        var result = controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var dtoOrders = Assert.IsAssignableFrom<IEnumerable<OrderDto>>(okResult.Value);
        Assert.Equal(orders.Count, dtoOrders.Count());
    }

    [TestMethod]
    public void GetAllSortedByDateAndPrice_Should_Return_All_Orders_Sorted()
    {
        // Arrange
        var orders = new List<Order>
        {
            new Order { OrderId = 1, OrderAt = DateTime.Now, NumberOfTickets = 3, TotalPrice = 100 },
            new Order { OrderId = 2, OrderAt = DateTime.Now.AddDays(-1), NumberOfTickets = 2, TotalPrice = 50 },
            new Order { OrderId = 3, OrderAt = DateTime.Now.AddDays(-2), NumberOfTickets = 1, TotalPrice = 20 }
        };

        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(repo => repo.GetAllSortedByDateAndPrice()).Returns(orders.OrderBy(o => o.OrderAt).ThenBy(o => o.TotalPrice));

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(mapper => mapper.Map<OrderDto>(It.IsAny<Order>())).Returns((Order order) => new OrderDto
        {
            OrderId = order.OrderId,
            OrderAt = order.OrderAt,
            NumberOfTickets = order.NumberOfTickets,
            TotalPrice = order.TotalPrice
        });

        var mockLogger = new Mock<ILogger<OrderController>>();

        var controller = new OrderController(mockOrderRepository.Object, mockMapper.Object, mockLogger.Object);

        // Act
        var result = controller.GetAllSortedByDateAndPrice();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var dtoOrders = Assert.IsAssignableFrom<IEnumerable<OrderDto>>(okResult.Value);
        Assert.Equal(orders.Count, dtoOrders.Count());

        var sortedOrders = orders.OrderBy(o => o.OrderAt).ThenBy(o => o.TotalPrice).ToList();
        for (int i = 0; i < dtoOrders.Count(); i++)
        {
            Assert.Equal(sortedOrders[i].OrderId, dtoOrders.ElementAt(i).OrderId);
            Assert.Equal(sortedOrders[i].OrderAt, dtoOrders.ElementAt(i).OrderAt);
            Assert.Equal(sortedOrders[i].NumberOfTickets, dtoOrders.ElementAt(i).NumberOfTickets);
            Assert.Equal(sortedOrders[i].TotalPrice, dtoOrders.ElementAt(i).TotalPrice);
        }
    }

    [TestMethod]
    public async Task GetById_Should_Return_Order_By_Id()
    {
        // Arrange
        long orderId = 1;
        var order = new Order { OrderId = orderId, OrderAt = DateTime.Now, NumberOfTickets = 3, TotalPrice = 100 };

        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(repo => repo.GetById(orderId)).ReturnsAsync(order);

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(mapper => mapper.Map<OrderDto>(It.IsAny<Order>())).Returns((Order order) => new OrderDto
        {
            OrderId = order.OrderId,
            OrderAt = order.OrderAt,
            NumberOfTickets = order.NumberOfTickets,
            TotalPrice = order.TotalPrice
        });

        var mockLogger = new Mock<ILogger<OrderController>>();

        var controller = new OrderController(mockOrderRepository.Object, mockMapper.Object, mockLogger.Object);

        // Act
        var result = await controller.GetById(orderId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var orderDto = Assert.IsType<OrderDto>(okResult.Value);
        Assert.Equal(orderId, orderDto.OrderId);
        Assert.Equal(order.OrderAt, orderDto.OrderAt);
        Assert.Equal(order.NumberOfTickets, orderDto.NumberOfTickets);
        Assert.Equal(order.TotalPrice, orderDto.TotalPrice);
    }

    [TestMethod]
    public async Task Delete_Should_Delete_Order_By_Id()
    {
        // Arrange
        long orderId = 1;
        var order = new Order { OrderId = orderId, OrderAt = DateTime.Now, NumberOfTickets = 3, TotalPrice = 100 };

        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(repo => repo.GetById(orderId)).ReturnsAsync(order);

        var mockMapper = new Mock<IMapper>();
        var mockLogger = new Mock<ILogger<OrderController>>();

        var controller = new OrderController(mockOrderRepository.Object, mockMapper.Object, mockLogger.Object);

        // Act
        var result = await controller.Delete(orderId);

        // Assert
        var noContentResult = Assert.IsType<NoContentResult>(result);
        mockOrderRepository.Verify(repo => repo.Delete(order), Times.Once);
    }

    [TestMethod]
    public async Task Patch_Should_Update_Order_Properties()
    {
        // Arrange
        long orderId = 1;
        var order = new Order { OrderId = orderId, OrderAt = DateTime.Now, NumberOfTickets = 3, TotalPrice = 100 };
        var orderPatch = new OrderDto { OrderId = orderId, OrderAt = DateTime.Now.AddDays(-1), NumberOfTickets = 2, TotalPrice = 50 };

        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(repo => repo.GetById(orderId)).ReturnsAsync(order);

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(mapper => mapper.Map<OrderDto>(It.IsAny<Order>())).Returns((Order order) => new OrderDto
        {
            OrderId = order.OrderId,
            OrderAt = order.OrderAt,
            NumberOfTickets = order.NumberOfTickets,
            TotalPrice = order.TotalPrice
        });

        var mockLogger = new Mock<ILogger<OrderController>>();

        var controller = new OrderController(mockOrderRepository.Object, mockMapper.Object, mockLogger.Object);

        // Act
        var result = await controller.Patch(orderPatch);


        // Verify that the correct order was retrieved
        mockOrderRepository.Verify(repo => repo.GetById(orderId), Times.Once);

        // Verify that the order properties are updated as expected
        Assert.Equal(orderPatch.OrderAt, order.OrderAt);
        Assert.Equal(orderPatch.NumberOfTickets, order.NumberOfTickets);
        Assert.Equal(orderPatch.TotalPrice, order.TotalPrice);

        // Verify that the order update method is called with the updated order
        mockOrderRepository.Verify(repo => repo.Update(order), Times.Once);
    }


}
