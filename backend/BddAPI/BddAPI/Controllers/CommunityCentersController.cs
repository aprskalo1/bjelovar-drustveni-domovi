using BddAPI.DTOs.Request;
using BddAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BddAPI.Controllers;

[ApiController]
[Route("api/community-centers")]
public class CommunityCentersController(ICommunityCentersService communityCentersService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateCommunityCenter(CommunityCenterRequestDto communityCenterRequestDto)
    {
        var communityCenter = await communityCentersService.CreateCommunityCenterAsync(communityCenterRequestDto);
        return Ok(communityCenter);
    }

    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetCommunityCenter(Guid id)
    {
        var communityCenter = await communityCentersService.GetCommunityCenterAsync(id);
        return Ok(communityCenter);
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetCommunityCenters(int quantity)
    {
        var communityCenters = await communityCentersService.GetCommunityCentersAsync(quantity);
        return Ok(communityCenters);
    }

    [HttpGet("get-by-availability")]
    public async Task<IActionResult> GetCommunityCentersByAvailability(DateTime startDate, DateTime endDate)
    {
        var communityCenters = await communityCentersService.GetCommunityCentersByAvailabilityAsync(startDate, endDate);
        return Ok(communityCenters);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateCommunityCenter(CommunityCenterRequestDto communityCenterRequestDto, Guid id)
    {
        var communityCenter = await communityCentersService.UpdateCommunityCenterAsync(communityCenterRequestDto, id);
        return Ok(communityCenter);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteCommunityCenter(Guid id)
    {
        await communityCentersService.DeleteCommunityCenterAsync(id);
        return Ok();
    }
}