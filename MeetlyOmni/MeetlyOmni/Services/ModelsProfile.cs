using AutoMapper;
using MeetlyOmni.Contracts.DTOs;
using MeetlyOmni.Models;

namespace MeetlyOmni.Services;

public class ModelsProfile : Profile
{
    // construct function
    public ModelsProfile()
    {
        // CreateMap<TSource, TDestination>()

        // retrieve EvenDto from database
        CreateMap<Event, EventDto>();
        // data sent by the client to create an event to an Event
        CreateMap<CreateEventDto, Event>();
        // data sent by the client to update an event to an Event
        CreateMap<UpdateEventDto, Event>();
    }
}
