using System.ComponentModel.DataAnnotations;

namespace BddAPI.DTOs.Request;

public class ReservationRequestDto
{
    [Required] public Guid UserId { get; set; }

    [Required] public Guid CommunityCenterId { get; set; }

    [Required] public DateTime ReservationFrom { get; set; }

    [Required] public DateTime ReservationTo { get; set; }

    public int? ExpectedNumberOfPeople { get; set; }

    [MaxLength(450)] public string? AdditionalNotes { get; set; }
}