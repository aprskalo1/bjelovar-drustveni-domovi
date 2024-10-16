using BddAPI.Data;
using BddAPI.Models;
using FirebaseAdmin.Auth;
using Microsoft.EntityFrameworkCore;

namespace BddAPI.Services;

public interface IDatabaseSeeder
{
    Task SeedAsync();
}

public class DatabaseSeeder(BddDbContext dbContext) : IDatabaseSeeder
{
    public async Task SeedAsync()
    {
        var superuserRoleId = Guid.Parse("7a64bde5-8705-4ad5-8d69-1aadd2108a89");
        var adminRoleId = Guid.Parse("c9b1f6c4-dce5-4b26-88b1-29b9b29f5d2b");
        var userRoleId = Guid.Parse("de19b1a7-8dc3-49e2-b98f-9990a9f59118");

        if (!await dbContext.Users.AnyAsync())
        {
            var superuser = await CreateUserAndSeedToDbAsync("superuser@superuser.com", "superuser", "test1234");
            var admin = await CreateUserAndSeedToDbAsync("admin@admin.com", "admin", "test1234");
            var regularUser = await CreateUserAndSeedToDbAsync("user@user.com", "user", "test1234");

            dbContext.UserRoles.AddRange(
                new UserRole { UserId = superuser.Id, RoleId = superuserRoleId },
                new UserRole { UserId = admin.Id, RoleId = adminRoleId },
                new UserRole { UserId = regularUser.Id, RoleId = userRoleId }
            );

            await dbContext.SaveChangesAsync();
        }
    }

    private async Task<User> CreateUserAndSeedToDbAsync(string email, string username, string password)
    {
        UserRecord firebaseUser;

        try
        {
            firebaseUser = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(email);
        }
        catch (FirebaseAuthException ex)
        {
            if (ex.AuthErrorCode == AuthErrorCode.UserNotFound)
            {
                var userArgs = new UserRecordArgs
                {
                    Email = email,
                    DisplayName = username,
                    Password = password,
                    EmailVerified = true,
                    Disabled = false,
                };

                firebaseUser = await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);
            }
            else
            {
                throw;
            }
        }

        var dbUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (dbUser != null) return dbUser;

        dbUser = new User
        {
            Id = Guid.NewGuid(),
            FirebaseUid = firebaseUser.Uid,
            Username = username,
            Email = email,
            CreatedAt = DateTime.Now
        };

        dbContext.Users.Add(dbUser);
        await dbContext.SaveChangesAsync();

        return dbUser;
    }
}