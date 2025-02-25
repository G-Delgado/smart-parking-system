public interface IIoTDeviceService
{
    IoTDevice RegisterDevice(CreateIoTDeviceDTO deviceDto);
    bool ValidateApiKey(string apiKey);
}