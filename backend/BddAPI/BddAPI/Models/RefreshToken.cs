using System.ComponentModel.DataAnnotations;

namespace BddAPI.Models;

public class RefreshToken
{
    [Key] public Guid Id { get; init; }

    public Guid UserId { get; init; }
    public User User { get; init; }

    [Required] [MaxLength(500)] public string Token { get; init; }
    public DateTime Expires { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.Now;
}