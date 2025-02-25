using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/parking-spots")]
public class ParkingController : ControllerBase
{
    private readonly IParkingService _service;

    public ParkingController(IParkingService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAllSpots());

    [HttpPut("{id}/occupy")]
    public IActionResult OccupySpot(Guid id, [FromBody] CreateParkingSpotDTO request)
    {
        if (_service.OccupySpot(id, request.DeviceId))
            return Ok("Spot occupied.");
        return BadRequest("Cannot occupy this spot.");
    }
    
    [HttpPut("{id}/free")]
    public IActionResult FreeSpot(Guid id, [FromBody] CreateParkingSpotDTO request)
    {
        if (_service.FreeSpot(id, request.DeviceId))
            return Ok("Spot freed.");
        return BadRequest("Cannot free this spot.");
    }

    [HttpPost]
    public IActionResult AddSpot([FromBody] CreateParkingSpotDTO request)
    {
        _service.AddSpot(request);
        return Ok("Spot added.");
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveSpot(Guid id)
    {
        _service.RemoveSpot(id);
        return Ok("Spot removed.");
    }
}
