using System.ComponentModel.DataAnnotations;

namespace BddAPI.DTOs.Request;

public class CommunityCenterRequestDto
{
    [Required] [MaxLength(50)] public string Name { get; init; }
    [Required] [MaxLength(50)] public string Address { get; init; }
    [Required] [MaxLength(50)] public string Settlement { get; init; }
    [Required] [MaxLength(450)] public string Description { get; init; }
}