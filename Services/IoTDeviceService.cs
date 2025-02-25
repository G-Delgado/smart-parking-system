public class IoTDeviceService : IIoTDeviceService
{
    private readonly IIotDeviceRepository _devices;


    public List<IoTDevice> GetAllDevices()
    {
        _devices.
    }

    public IoTDevice? GetDeviceById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IoTDevice AddDevice(CreateIoTDeviceDTO deviceDto)
    {
        var device = new IoTDevice
        {
            Id = Guid.NewGuid(),
            Name = deviceDto.Name,
            ApiKey = Guid.NewGuid().ToString()
        };

        _devices.Add(device);
        return device;
    }

    public bool RemoveDevice(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool UpdateDevice(Guid id, IoTDeviceDTO deviceDto)
    {
        throw new NotImplementedException();
    }

    public bool ValidateApiKey(string apiKey)
    {
        return _devices.Any(d => d.ApiKey == apiKey);
    }
}
