using BddAPI.Data;
using BddAPI.Exceptions;
using BddAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BddAPI.Repositories;

public interface IUserRepository
{
    Task<User> CreateUserAsync(User user);
    Task<User?> GetUserByUsernameAsync(string username);
    Task<User?> GetUserByFirebaseUid(string username);
    Task AssignRoleToUser(UserRole role);
    Task<Role> GetDefaultRole();
    Task SaveChangesAsync();
}

public class UserRepository(BddDbContext dbContext) : IUserRepository
{
    public async Task<User> CreateUserAsync(User user)
    {
        await dbContext.Users.AddAsync(user);
        return user;
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User?> GetUserByFirebaseUid(string username)
    {
        return await dbContext.Users.FirstOrDefaultAsync(u => u.FirebaseUid == username);
    }

    public async Task AssignRoleToUser(UserRole userRole)
    {
        await dbContext.UserRoles.AddAsync(userRole);
    }

    public async Task<Role> GetDefaultRole()
    {
        return await dbContext.Roles.FirstOrDefaultAsync(r => r.Name == "User") ?? throw new UserException("Default role not found");
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}