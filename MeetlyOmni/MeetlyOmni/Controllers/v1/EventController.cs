using Asp.Versioning;
using AutoMapper;
using MeetlyOmni.Contracts.DTOs;
using MeetlyOmni.Contracts.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MeetlyOmni.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            this._eventService = eventService;
        }

        [HttpPost]
        public async Task<EventDto> CreateEvent(CreateEventDto input)
        {
            var result = await _eventService.AddAsync(input);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<EventDto> DeleteEvent(Guid id)
        {
            var result = await _eventService.DeleteAsync(id);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<EventDto> UpdateEvent(Guid id, UpdateEventDto input)
        {
            var result = await _eventService.UpdateAsync(id, input);
            result.UpdatedAt = DateTime.Now;
            return result;
        }

        [HttpGet("{id}")]
        public async Task<EventDto> GetEventById(Guid id)
        {
            var result = await _eventService.GetByIdAsync(id);
            return result;
        }

        [HttpGet("events")]
        public async Task<List<EventDto>> GetAllEvents()
        {
            var result = await _eventService.GetAllAsync();
            return result;
        }
    }
}
