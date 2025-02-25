using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/parking-spots")]
public class ParkingController : ControllerBase
{
    private readonly ParkingService _service;

    public ParkingController(ParkingService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAllSpots());

    [HttpPost("{id}/occupy")]
    public IActionResult OccupySpot(Guid id, [FromBody] CreateParkingSpotDTO request)
    {
        if (_service.OccupySpot(id, request.DeviceId))
            return NoContent();
        return BadRequest("Cannot occupy this spot.");
    }

    [HttpPost("{id}/free")]
    public IActionResult FreeSpot(Guid id, [FromBody] CreateParkingSpotDTO request)
    {
        if (_service.FreeSpot(id, request.DeviceId))
            return NoContent();
        return BadRequest("Cannot free this spot.");
    }

    [HttpPost]
    public IActionResult AddSpot()
    {
        _service.AddSpot();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveSpot(Guid id)
    {
        _service.RemoveSpot(id);
        return NoContent();
    }
}
