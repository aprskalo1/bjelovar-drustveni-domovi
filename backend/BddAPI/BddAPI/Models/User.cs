using System.ComponentModel.DataAnnotations;

namespace BddAPI.Models;

public class User
{
    [Key] public Guid Id { get; init; }
    public string? FirebaseUid { get; set; }
    [MaxLength(50)] public string? Username { get; init; }
    [MaxLength(50)] public string? FirstName { get; init; }
    [MaxLength(50)] public string? LastName { get; init; }
    [MaxLength(50)] public string? Email { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.Now;
}