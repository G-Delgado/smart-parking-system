
using System.ComponentModel.DataAnnotations;

public class CreateIoTDeviceDTO
{
    [Required]
    public required string Name { get; set; }
}