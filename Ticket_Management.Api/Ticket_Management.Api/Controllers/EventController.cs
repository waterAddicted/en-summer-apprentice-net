﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket_Management.Api.Models;
using Ticket_Management.Api.Models.DTOs;
using Ticket_Management.Api.Repositories;

namespace Ticket_Management.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public ActionResult<List<EventDto>> GetAll()
        {
            var events = _eventRepository.GetAll();

            var dtoEvents = events.Select(e => new EventDto()
            {
                EventId = e.EventId,
                EventDescription = e.EventDescription,
                EventName = e.EventName,
                EventType = e.EventType?.EventTypeName ?? string.Empty,
                Venue = e.Venue?.Location ?? string.Empty
            });


            return Ok(dtoEvents);
        }


        [HttpGet]
        public ActionResult<EventDto> GetById(long id)
        {
            try
            {
                var @event = _eventRepository.GetById(id);

                if (@event == null)
                {
                    return NotFound();
                }

                var dtoEvent = new EventDto()
                {
                    EventId = @event.EventId,
                    EventDescription = @event.EventDescription,
                    EventName = @event.EventName,
                    EventType = @event.EventType?.EventTypeName ?? string.Empty,
                    Venue = @event.Venue?.Location ?? string.Empty
                };

                return Ok(dtoEvent);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
        
        [HttpGet]
        public ActionResult<EventDto> GetByName(string name)
        {
            var @event = _eventRepository.GetByName(name);
            if (@event == null)
                {
                return NotFound();
                }
            var dtoEvent = new EventDto()
            {
                EventId = @event.EventId,
                EventDescription = @event.EventDescription,
                EventName = @event.EventName,
                EventType = @event.EventType?.EventTypeName ?? string.Empty,
                Venue = @event.Venue?.Location ?? string.Empty
            };
            return Ok(dtoEvent);
        }
    }


}
