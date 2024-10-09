using System.ComponentModel.DataAnnotations;

namespace BddAPI.Models;

public class CommunityCenter
{
    [Key] public Guid Id { get; init; }
    
    [Required] [MaxLength(50)] public string Name { get; init; }
    [Required] [MaxLength(50)] public string Address { get; init; }
    [Required] [MaxLength(50)] public string Settlement { get; init; }
    [Required] [MaxLength(450)] public string Description { get; init; }
    
    public DateTime CreatedAt { get; init; } = DateTime.Now;
}