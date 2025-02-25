public interface IParkingService {

    List<ParkingSpotDTO> GetAllSpots();
    bool OccupySpot(Guid id, Guid deviceId);
    bool FreeSpot(Guid id, Guid deviceId);
    bool AddSpot(CreateParkingSpotDTO createParkingSpotDTO);
    void RemoveSpot(Guid id);
    
}