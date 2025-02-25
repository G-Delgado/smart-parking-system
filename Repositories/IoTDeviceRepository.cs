public class IotDeviceRepository : IIotDeviceRepository
{
    private readonly List<IoTDevice> _devices = new();

    public List<IoTDevice> GetAll() => _devices;
    public IoTDevice? GetById(Guid id) => _devices.FirstOrDefault(s => s.Id == id);
    public void Add(IoTDevice device) => _devices.Add(device);
    public void Remove(Guid id) => _devices.RemoveAll(s => s.Id == id);
    public void Update(IoTDevice device)
    {
        var existingDevice = GetById(device.Id);
        if (existingDevice != null)
        {
            existingDevice.Name = device.Name;
            existingDevice.ParkingSpotAssigned = device.ParkingSpotAssigned;
        }
    }


}
