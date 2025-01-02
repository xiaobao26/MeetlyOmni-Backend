using MeetlyOmni.Models.Enums;

namespace MeetlyOmni.Models;

public class Event
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string EventName { get; set; }
    public Guid GameId { get; set; }
    public string Pin { get; set; }
    public Guid HostUserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int UserLimit { get; set; }
    public string Location { get; set; }
    public AccessMode AccessMode { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public GameType Type { get; set; }
    public Guid GameMasterId { get; set; }
}
