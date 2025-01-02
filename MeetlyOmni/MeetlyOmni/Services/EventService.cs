using AutoMapper;
using MeetlyOmni.Contracts.DTOs;
using MeetlyOmni.Contracts.IServices;
using MeetlyOmni.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetlyOmni.Services;

public class EventService : IEventService
{
    // database mapper
    private readonly OmniDbContext _omniDbContext;
    private readonly IMapper _mapper;

    // construct function
    public EventService(OmniDbContext omniDbContext, IMapper mapper)
    {
        this._omniDbContext = omniDbContext;
        this._mapper = mapper;
    }

    public async Task<EventDto> AddAsync(CreateEventDto input)
    {
        Event evt = this._mapper.Map<Event>(input);
        this._omniDbContext.Add(evt);
        await this._omniDbContext.SaveChangesAsync();
        EventDto eventDto = this._mapper.Map<EventDto>(evt);
        return eventDto;
    }

    public async Task<EventDto> DeleteAsync(Guid id)
    {
        var targetEvent = await this._omniDbContext.Events.FindAsync(id);
        if (targetEvent == null)
            return null;

        this._omniDbContext.Events.Remove(targetEvent);
        await this._omniDbContext.SaveChangesAsync();
        EventDto eventDto = this._mapper.Map<EventDto>(targetEvent);
        return eventDto;
    }

    public async Task<EventDto> UpdateAsync(Guid id, UpdateEventDto input)
    {
        var targetEvent = await this._omniDbContext.Events.FindAsync(id);

        // apply update
        // call applies the changes from UpdateEventDto to the targetEvent entity.
        this._mapper.Map(input, targetEvent);
        targetEvent.UpdatedAt = DateTime.Now;
        await this._omniDbContext.SaveChangesAsync();
        EventDto eventDto = this._mapper.Map<EventDto>(targetEvent);
        return eventDto;
    }

    public async Task<EventDto> GetByIdAsync(Guid id)
    {
        var targetEvent = await this._omniDbContext.Events.FindAsync(id);
        if (targetEvent == null)
            return null;

        EventDto eventDto = this._mapper.Map<EventDto>(targetEvent);
        return eventDto;
    }

    public async Task<List<EventDto>> GetAllAsync()
    {
        var events = await this._omniDbContext.Events.ToListAsync();
        if (events == null)
            return null;

        List<EventDto> eventDtos = this._mapper.Map<List<EventDto>>(events);
        return eventDtos;
    }
}
