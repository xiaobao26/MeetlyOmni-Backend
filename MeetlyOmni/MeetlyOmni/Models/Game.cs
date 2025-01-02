using MeetlyOmni.Models.Enums;

namespace MeetlyOmni.Models;

public class Game
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid CreatedUserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public GameType Type { get; set; }
    public Guid MasterGameId { get; set; }
    public int Version { get; set; }
    public bool IsLatest { get; set; } = true;
}
