public class IoTDevice
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string ApiKey { get; set; } = Guid.NewGuid().ToString();    

    public ParkingSpot? ParkingSpotAssigned { get; set; } = null;
}
