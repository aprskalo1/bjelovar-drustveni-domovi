using BddAPI.DTOs.Request;
using BddAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BddAPI.Controllers;

[ApiController]
[Route("api/reservations")]
public class ReservationsController(IReservationsService reservationService) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateReservation(ReservationRequestDto reservationRequestDto)
    {
        var reservation = await reservationService.CreateReservationAsync(reservationRequestDto);
        return Ok(reservation);
    }

    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetReservation(Guid id)
    {
        var reservation = await reservationService.GetReservationAsync(id);
        return Ok(reservation);
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetReservations(int quantity)
    {
        var reservations = await reservationService.GetReservationsAsync(quantity);
        return Ok(reservations);
    }

    [HttpGet("get-by-date-range")]
    public async Task<IActionResult> GetReservationsByDateRange(DateTime startDate, DateTime endDate)
    {
        var reservations = await reservationService.GetReservationsByDateRangeAsync(startDate, endDate);
        return Ok(reservations);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateReservation(ReservationRequestDto reservationRequestDto, Guid id)
    {
        var reservation = await reservationService.UpdateReservationAsync(reservationRequestDto, id);
        return Ok(reservation);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteReservation(Guid id)
    {
        await reservationService.DeleteReservationAsync(id);
        return Ok();
    }
}