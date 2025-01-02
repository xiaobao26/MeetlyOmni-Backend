using MeetlyOmni.Contracts.DTOs;

namespace MeetlyOmni.Contracts.IServices
{
    public interface IEventService
    {
        Task<EventDto> AddAsync(CreateEventDto input);
        Task<EventDto> DeleteAsync(Guid id);
        Task<EventDto> UpdateAsync(Guid id, UpdateEventDto input);
        Task<EventDto> GetByIdAsync(Guid id);
        Task<List<EventDto>> GetAllAsync();
    }
}
