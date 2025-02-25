public class IoTDevice
{
    private Guid Id { get; set; } = Guid.NewGuid();
    private string Name { get; set; } = string.Empty;
    private string ApiKey { get; set; } = Guid.NewGuid().ToString();    

    private ParkingSpot? ParkingSpotAssigned { get; set; } = null;
}
