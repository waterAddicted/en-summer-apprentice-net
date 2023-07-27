using AutoMapper;
using Ticket_Management.Api.Models.DTOs;
using Ticket_Management.Api.Models;

namespace Ticket_Management.Api.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            //CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
