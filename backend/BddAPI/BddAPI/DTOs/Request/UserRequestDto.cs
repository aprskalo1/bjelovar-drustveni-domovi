using System.ComponentModel.DataAnnotations;

namespace BddAPI.DTOs.Request;

public class UserRequestDto
{
    [MaxLength(50)] public string? FirebaseUid { get; init; }
    [Required] [MaxLength(50)] public string Username { get; init; }
    [MaxLength(50)] public string? FirstName { get; init; }
    [MaxLength(50)] public string? LastName { get; init; }
    [Required] [MaxLength(50)] public string Email { get; init; }
}