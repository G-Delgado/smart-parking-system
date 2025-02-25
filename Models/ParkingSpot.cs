public class ParkingSpot
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public ParkingState State { get; set; }

    public IoTDevice? IotDeviceAssigned { get; set; }
    
}
