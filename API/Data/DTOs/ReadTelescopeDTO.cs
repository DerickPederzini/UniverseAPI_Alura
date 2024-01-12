using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs;

public class ReadTelescopeDTO
{
    public int Id { get; set; }

    public ReadAddressDTO ReadAddressDTO { get; set; }

    public string Name { get; set; }

    public ICollection<ReadUniverseDTO> Celestial { get; set; }

}
