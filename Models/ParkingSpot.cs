public class ParkingSpot
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsOccupied { get; set; } = false;
    public Guid? OccupiedByDevice { get; set; } // Id of the IoT in charge of the Parking Spot.
}
