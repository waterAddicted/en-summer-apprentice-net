using AutoMapper;
using Ticket_Management.Api.Models.DTOs;
using Ticket_Management.Api.Models;

namespace Ticket_Management.Api.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>().ReverseMap();
            //CreateMap<Event, EventDto>().ReverseMap();
        }
    }
}
