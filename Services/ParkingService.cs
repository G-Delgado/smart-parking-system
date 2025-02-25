public class ParkingService : IParkingService
{
    private readonly IParkingRepository _repository;
    private readonly IIotDeviceRepository _deviceRepository;
    
    public ParkingService(IParkingRepository repository, IIotDeviceRepository deviceRepository)
    {
        _repository = repository;
        _deviceRepository = deviceRepository;
    }

    public List<ParkingSpotDTO> GetAllSpots()
    {
        return _repository.GetAll().Select(spot => new ParkingSpotDTO
        {
            Id = spot.Id,
            State = spot.State.ToString(),
        }).ToList();
    }

    public bool OccupySpot(Guid id, Guid deviceId)
    {
        var spot = _repository.GetById(id);
        Console.WriteLine(spot?.IotDeviceAssigned.Id);
        Console.WriteLine("incoming " + deviceId);
        if (spot == null || spot.IotDeviceAssigned?.Id != deviceId || spot.State == ParkingState.Occupied) return false;
        
        spot.State = ParkingState.Occupied;
        // spot.IotDeviceAssigned = deviceId;
        Console.WriteLine("Got here...");
        _repository.Update(spot);
        return true;
    }

    public bool FreeSpot(Guid id, Guid deviceId)
    {
        var spot = _repository.GetById(id);
        var device = _deviceRepository.GetById(deviceId);
        if (spot == null || spot.State == ParkingState.Free || spot.IotDeviceAssigned?.Id != deviceId) return false;
        
        spot.State = ParkingState.Free;
        //spot.OccupiedByDevice = null;
        _repository.Update(spot);
        return true;
    }

    public bool AddSpot(CreateParkingSpotDTO createParkingSpotDTO)
    {
        // Get IotDevice
        var device = _deviceRepository.GetById(createParkingSpotDTO.DeviceId);

        if (device == null) return false;
        var spot = new ParkingSpot
        {
            Id = Guid.NewGuid(),
            State = ParkingState.Free,
            IotDeviceAssigned = device
        };
        device.ParkingSpotAssigned = spot;
        _deviceRepository.Update(device);
        _repository.Add(spot);

        Console.WriteLine("Spot added: ");
        Console.WriteLine(device.Id);

        return true;
    } 
        

    public void RemoveSpot(Guid id) => _repository.Remove(id);
}
