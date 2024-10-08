using BddAPI.Data;
using BddAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BddAPI.Repositories;

public interface IUserRepository
{
    Task<User> CreateUserAsync(User user);
    Task<User?> GetUserByUsernameAsync(string username);
    Task SaveChangesAsync();
}

public class UserRepository(BddDbContext dbContext) : IUserRepository
{
    public async Task<User> CreateUserAsync(User user)
    {
        await dbContext.Users.AddAsync(user);
        return user;
    }

    public Task<User?> GetUserByUsernameAsync(string username)
    {
        return dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}