public interface IParkingRepository
{
    List<ParkingSpot> GetAll();
    ParkingSpot? GetById(Guid id);
    void Add(ParkingSpot spot);
    void Remove(Guid id);
    void Update(ParkingSpot spot);
}
