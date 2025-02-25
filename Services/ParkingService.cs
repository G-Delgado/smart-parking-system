public class ParkingService
{
    private readonly IParkingRepository _repository;
    
    public ParkingService(IParkingRepository repository)
    {
        _repository = repository;
    }

    public List<ParkingSpotDTO> GetAllSpots()
    {
        return _repository.GetAll().Select(spot => new ParkingSpotDTO
        {
            Id = spot.Id,
            IsOccupied = spot.IsOccupied
        }).ToList();
    }

    public bool OccupySpot(Guid id, Guid deviceId)
    {
        var spot = _repository.GetById(id);
        if (spot == null || spot.IsOccupied) return false;
        
        spot.IsOccupied = true;
        spot.OccupiedByDevice = deviceId;
        _repository.Update(spot);
        return true;
    }

    public bool FreeSpot(Guid id, Guid deviceId)
    {
        var spot = _repository.GetById(id);
        if (spot == null || !spot.IsOccupied || spot.OccupiedByDevice != deviceId) return false;
        
        spot.IsOccupied = false;
        spot.OccupiedByDevice = null;
        _repository.Update(spot);
        return true;
    }

    public void AddSpot() => _repository.Add(new ParkingSpot());

    public void RemoveSpot(Guid id) => _repository.Remove(id);
}
