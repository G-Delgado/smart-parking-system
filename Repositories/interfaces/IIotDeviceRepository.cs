public interface IIotDeviceRepository
{
    List<IoTDevice> GetAll();
    IoTDevice? GetById(Guid id);
    void Add(IoTDevice device);
    void Remove(Guid id);
    void Update(IoTDevice device);
}