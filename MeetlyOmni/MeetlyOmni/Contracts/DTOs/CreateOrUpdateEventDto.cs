using System.ComponentModel.DataAnnotations;
using MeetlyOmni.Core;
using MeetlyOmni.Models.Enums;

namespace MeetlyOmni.Contracts.DTOs;

public class CreateOrUpdateEventDto
{
    [Required(ErrorMessage = "EventName is required!")]
    [StringLength(255, ErrorMessage = "Event Name must be between 1 and 255 characters.")]
    public string EventName { get; set; }

    [Required(ErrorMessage = "GameId is required!")]
    public Guid GameId { get; set; }

    [Required(ErrorMessage = "Game Master Id is required!")]
    public Guid GameMasterId { get; set; }

    [Required(ErrorMessage = "HostUserId is required!")]
    public Guid HostUserId { get; set; }

    [Required(ErrorMessage = "Pin is required!")]
    [RegularExpression(
        @"^[a-zA-Z0-9]{6}$",
        ErrorMessage = "Pin must be 6 characters long exactly, and only contain alphanumeric character"
    )]
    public string Pin { get; set; }

    [Required(ErrorMessage = "User limit number is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "User limit number must be at least 1!")]
    public int UserLimit { get; set; }

    [Required(ErrorMessage = "Location is required!")]
    [StringLength(255, ErrorMessage = "Location must be between 1 and 255 characters.")]
    public string Location { get; set; }

    [Required(ErrorMessage = "AccessMode is required!")]
    [EnumDataType(typeof(AccessMode), ErrorMessage = "Access Mode is invalid!")]
    public AccessMode AccessMode { get; set; }

    [Required(ErrorMessage = "Game type is required!")]
    [EnumDataType(typeof(GameType), ErrorMessage = "Game type is invalid!")]
    public GameType Type { get; set; }

    [DateValidation("StartTime", "EndTime")]
    [Required(ErrorMessage = "StartTime is required!")]
    public DateTime StartTime { get; set; }

    [Required(ErrorMessage = "EndTime is required!")]
    public DateTime EndTime { get; set; }
}
