using BddAPI.Data;
using BddAPI.Exceptions;
using BddAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BddAPI.Repositories;

public interface ICommunityCentersRepository
{
    Task<CommunityCenter> CreateCommunityCenterAsync(CommunityCenter communityCenter);
    Task<CommunityCenter?> GetCommunityCenterAsync(Guid id);
    Task<IEnumerable<CommunityCenter?>> GetCommunityCentersAsync(int quantity);
    Task<IEnumerable<CommunityCenter>> GetAllCommunityCentersAsync();
    Task<CommunityCenter> UpdateCommunityCenterAsync(CommunityCenter communityCenter);
    Task DeleteCommunityCenterAsync(Guid id);
    Task SaveChangesAsync();
}

public class CommunityCentersRepository(BddDbContext dbContext, IReservationsRepository reservationsRepository)
    : ICommunityCentersRepository
{
    public async Task<CommunityCenter> CreateCommunityCenterAsync(CommunityCenter communityCenter)
    {
        await dbContext.CommunityCenters.AddAsync(communityCenter);
        return communityCenter;
    }

    public async Task<CommunityCenter?> GetCommunityCenterAsync(Guid id)
    {
        return await dbContext.CommunityCenters.FindAsync(id);
    }

    public async Task<IEnumerable<CommunityCenter?>> GetCommunityCentersAsync(int quantity)
    {
        return await dbContext.CommunityCenters.Take(quantity).ToListAsync();
    }

    public async Task<IEnumerable<CommunityCenter>> GetAllCommunityCentersAsync()
    {
        return await dbContext.CommunityCenters.ToListAsync();
    }

    public async Task<CommunityCenter> UpdateCommunityCenterAsync(CommunityCenter communityCenter)
    {
        dbContext.CommunityCenters.Update(communityCenter);
        await dbContext.SaveChangesAsync();
        return communityCenter;
    }

    public async Task DeleteCommunityCenterAsync(Guid id)
    {
        var communityCenter = await dbContext.CommunityCenters.FindAsync(id);

        if (communityCenter == null)
        {
            throw new NotFoundException($"Community Center with ID: {id} not found");
        }

        dbContext.CommunityCenters.Remove(communityCenter);
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}