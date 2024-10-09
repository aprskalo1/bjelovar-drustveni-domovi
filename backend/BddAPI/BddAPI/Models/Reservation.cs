using System.ComponentModel.DataAnnotations;

namespace BddAPI.Models;

public class Reservation
{
    [Key] public Guid Id { get; init; }

    public Guid UserId { get; init; }
    public User User { get; init; } = null!;

    public Guid CommunityCenterId { get; init; }
    public CommunityCenter CommunityCenter { get; init; } = null!;

    [Required] public DateTime ReservationFrom { get; init; }
    [Required] public DateTime ReservationTo { get; init; }
    public int? ExpectedNumberOfPeople { get; init; }
    [MaxLength(450)] public string? AdditionalNotes { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.Now;
}