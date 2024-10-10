using System.ComponentModel.DataAnnotations;

namespace BddAPI.Models;

public class User
{
    [Key] public Guid Id { get; init; }
    
    [MaxLength(50)] public string? FirebaseUid { get; init; }
    [MaxLength(50)] public string Username { get; init; } 
    [MaxLength(50)] public string? FirstName { get; init; }
    [MaxLength(50)] public string? LastName { get; init; }
    [MaxLength(50)] public string Email { get; init; }
    [MaxLength(50)] public string? Address { get; init; }
    [MaxLength(50)] public string? City { get; init; }
    [MaxLength(50)] public string? Oib { get; init; }
    [MaxLength(50)] public string? Bank { get; init; }
    [MaxLength(50)] public string? Iban { get; init; }
    [MaxLength(50)] public string? PhoneNumber { get; init; }
    
    public DateTime CreatedAt { get; init; } = DateTime.Now;
}