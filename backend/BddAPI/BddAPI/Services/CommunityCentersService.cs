using AutoMapper;
using BddAPI.DTOs.Request;
using BddAPI.DTOs.Response;
using BddAPI.Exceptions;
using BddAPI.Models;
using BddAPI.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace BddAPI.Services;

public interface ICommunityCentersService
{
    Task<CommunityCenterResponseDto> CreateCommunityCenterAsync(CommunityCenterRequestDto communityCenterRequestDto);
    Task<CommunityCenterResponseDto> GetCommunityCenterAsync(Guid communityCenterId);
    Task<IEnumerable<CommunityCenterResponseDto>> GetCommunityCentersAsync(int quantity);
    Task<IEnumerable<CommunityCenterResponseDto>> GetCommunityCentersByAvailabilityAsync(DateTime startDate, DateTime endDate);
    Task<CommunityCenterResponseDto> UpdateCommunityCenterAsync(CommunityCenterRequestDto communityCenterRequestDto, Guid id);
    Task DeleteCommunityCenterAsync(Guid communityCenterId);
}

public class CommunityCentersService(ICommunityCentersRepository communityCentersRepository, IReservationsRepository reservationsRepository, IMapper mapper) : ICommunityCentersService
{
    public async Task<CommunityCenterResponseDto> CreateCommunityCenterAsync(CommunityCenterRequestDto communityCenterRequestDto)
    {
        var communityCenter = mapper.Map<CommunityCenter>(communityCenterRequestDto);

        await communityCentersRepository.CreateCommunityCenterAsync(communityCenter);
        await communityCentersRepository.SaveChangesAsync();

        return mapper.Map<CommunityCenterResponseDto>(communityCenter);
    }

    public async Task<CommunityCenterResponseDto> GetCommunityCenterAsync(Guid communityCenterId)
    {
        var communityCenter = await communityCentersRepository.GetCommunityCenterAsync(communityCenterId);

        if (communityCenter == null)
        {
            throw new NotFoundException($"Community Center with ID: {communityCenterId} not found");
        }

        return mapper.Map<CommunityCenterResponseDto>(communityCenter);
    }

    public async Task<IEnumerable<CommunityCenterResponseDto>> GetCommunityCentersAsync(int quantity)
    {
        var communityCenters = await communityCentersRepository.GetCommunityCentersAsync(quantity);

        if (communityCenters.IsNullOrEmpty())
        {
            throw new NotFoundException("No community centers found");
        }

        return mapper.Map<IEnumerable<CommunityCenterResponseDto>>(communityCenters);
    }

    public async Task<IEnumerable<CommunityCenterResponseDto>> GetCommunityCentersByAvailabilityAsync(DateTime startDate, DateTime endDate)
    {
        var reservations = await reservationsRepository.GetReservationsByDateRangeAsync(startDate, endDate);

        IEnumerable<CommunityCenter> availableCommunityCenters;

        if (reservations == null || reservations.Count == 0)
        {
            availableCommunityCenters = await communityCentersRepository.GetAllCommunityCentersAsync();
        }
        else
        {
            var reservedCommunityCenterIds = reservations
                .Select(r => r.CommunityCenterId)
                .Distinct();

            availableCommunityCenters = (await communityCentersRepository.GetAllCommunityCentersAsync())
                .Where(c => !reservedCommunityCenterIds.Contains(c.Id));
        }

        return mapper.Map<IEnumerable<CommunityCenterResponseDto>>(availableCommunityCenters);
    }

    public async Task<CommunityCenterResponseDto> UpdateCommunityCenterAsync(CommunityCenterRequestDto communityCenterRequestDto, Guid id)
    {
        var communityCenter = await communityCentersRepository.GetCommunityCenterAsync(id);

        if (communityCenter == null)
        {
            throw new NotFoundException($"Community Center with ID: {id} not found");
        }

        mapper.Map(communityCenterRequestDto, communityCenter);
        await communityCentersRepository.UpdateCommunityCenterAsync(communityCenter);

        return mapper.Map<CommunityCenterResponseDto>(communityCenter);
    }

    public async Task DeleteCommunityCenterAsync(Guid communityCenterId)
    {
        await communityCentersRepository.DeleteCommunityCenterAsync(communityCenterId);
        await communityCentersRepository.SaveChangesAsync();
    }
}