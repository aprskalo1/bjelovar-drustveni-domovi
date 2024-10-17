namespace BddAPI.DTOs.Response;

public class ReservationResponseDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid CommunityCenterId { get; set; }

    public DateTime ReservationFrom { get; set; }

    public DateTime ReservationTo { get; set; }

    public int? ExpectedNumberOfPeople { get; set; }

    public string? AdditionalNotes { get; set; }
    
    public CommunityCenterResponseDto CommunityCenter { get; set; }
}