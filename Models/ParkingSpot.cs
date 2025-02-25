public class ParkingSpot
{
    private Guid Id { get; set; } = Guid.NewGuid();

    private ParkingState State { get; set; } = ParkingState.Free;

    private IoTDevice? IotDeviceAssigned { get; set; } = null;
    
}
