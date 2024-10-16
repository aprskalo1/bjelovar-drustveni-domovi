namespace BddAPI.DTOs.Response;

public class CommunityCenterResponseDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Address { get; init; }
    public string Settlement { get; init; }
    public string Description { get; init; }
    public int Capacity { get; init; }
    public bool Price { get; init; }
    public string PictureUrl { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.Now;
}