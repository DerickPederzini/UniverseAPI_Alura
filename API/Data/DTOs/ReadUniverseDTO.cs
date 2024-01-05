using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs;

public class ReadUniverseDTO
{

    public string Name { get; set; }

    public string Classification { get; set; }

    public bool EmitsLight { get; set; }

    public double Mass { get; set; }

    public ReadAddressDTO Address { get; set; }

    public DateTime consultTime {  get; set; } = DateTime.Now;

    
}
