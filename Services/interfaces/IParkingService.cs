public interface IParkingService {

    List<ParkingSpotDTO> GetAllSpots();
    bool OccupySpot(Guid id, Guid deviceId);
    bool FreeSpot(Guid id, Guid deviceId);
    void AddSpot();
    void RemoveSpot(Guid id);
    
}