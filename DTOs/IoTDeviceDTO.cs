public class IoTDeviceDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public Guid ParkingSpotId { get; set; }
}