public class IoTDeviceService : IIoTDeviceService
{
    private readonly IIotDeviceRepository _repository;

    private readonly IParkingRepository _parkingRepository;

    public IoTDeviceService(IIotDeviceRepository repository, IParkingRepository parkingRepository)
    {
        _repository = repository;
        _parkingRepository = parkingRepository;
    }


    public List<IoTDevice> GetAllDevices()
    {
        return _repository.GetAll();
    }

    public IoTDevice? GetDeviceById(Guid id)
    {
        return _repository.GetById(id);
    }

    public IoTDevice AddDevice(CreateIoTDeviceDTO deviceDto)
    {
        var device = new IoTDevice
        {
            Id = Guid.NewGuid(),
            Name = deviceDto.Name,
            ApiKey = Guid.NewGuid().ToString()
        };

        _repository.Add(device);
        return device;
    }

    public bool RemoveDevice(Guid id)
    {
        _repository.Remove(id);
        return true;
    }

    public bool UpdateDevice(Guid id, IoTDeviceDTO deviceDto)
    {
        // Get Parking Spot By Id
        var parkingSpot = _parkingRepository.GetById(deviceDto.ParkingSpotId);
        if (parkingSpot == null) return false;

        _repository.Update(new IoTDevice
        {
            Id = id,
            Name = deviceDto.Name,
            ParkingSpotAssigned = parkingSpot
        });

        return true;
    }

    public bool ValidateApiKey(string apiKey)
    {
        return _repository.GetAll().Any(d => d.ApiKey == apiKey);
    }
}
