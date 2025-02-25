public class IoTDeviceService : IIoTDeviceService
{
    private readonly List<IoTDevice> _devices = new();

    public IoTDevice RegisterDevice(CreateIoTDeviceDTO deviceDto)
    {
        var device = new IoTDevice
        {
            Id = Guid.NewGuid(),
            Name = deviceDto.Name,
            // Generating a random API Key
            ApiKey = Guid.NewGuid().ToString()
        };

        _devices.Add(device);
        return device;
    }

    public bool ValidateApiKey(string apiKey)
    {
        return _devices.Any(d => d.ApiKey == apiKey);
    }
}
