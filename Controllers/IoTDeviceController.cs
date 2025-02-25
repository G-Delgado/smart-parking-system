using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/iot-devices")]
[Authorize(Roles = "Admin")]
public class IoTDeviceController : ControllerBase
{
    private readonly IIoTDeviceService _service;

    public IoTDeviceController(IIoTDeviceService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAllDevices());

    [HttpPost]
    public IActionResult AddDevice([FromBody] CreateIoTDeviceDTO request)
    {
        _service.AddDevice(request);
        return Ok("Device added.");
    }

    
}