public interface IIoTDeviceService
{
    IoTDevice AddDevice(CreateIoTDeviceDTO deviceDto);
    List<IoTDevice> GetAllDevices();
    IoTDevice? GetDeviceById(Guid id);

    bool RemoveDevice(Guid id);
    bool UpdateDevice(Guid id, IoTDeviceDTO deviceDto);
    bool ValidateApiKey(string apiKey);
}