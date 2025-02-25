public class ParkingRepository : IParkingRepository
{
    private readonly List<ParkingSpot> _parkingSpots = new();

    public List<ParkingSpot> GetAll() => _parkingSpots;
    public ParkingSpot? GetById(Guid id) => _parkingSpots.FirstOrDefault(s => s.Id == id);
    public void Add(ParkingSpot spot) => _parkingSpots.Add(spot);
    public void Remove(Guid id) => _parkingSpots.RemoveAll(s => s.Id == id);
    public void Update(ParkingSpot spot)
    {
        var existingSpot = GetById(spot.Id);
        if (existingSpot != null)
        {
            existingSpot.State = spot.State;
            existingSpot.IotDeviceAssigned = spot.IotDeviceAssigned;
        }
    }
}
