public interface IIotDeviceRepository
{
    List<IoTDevice> GetAll();
    IoTDevice? GetById(string deviceId);
    void Add(IoTDevice device);
    void Remove(Guid id);
    void Update(IoTDevice device);
}