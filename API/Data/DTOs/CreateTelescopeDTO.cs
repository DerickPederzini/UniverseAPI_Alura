using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs;

public class CreateTelescopeDTO
{
    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public string Name { get; set; }

    public int AddressId { get; set; }

    public int CelestiaId { get; set; }

}
