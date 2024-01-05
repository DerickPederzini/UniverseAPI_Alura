using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs;

public class UpdateTelescopeDTO
{

    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public string Name { get; set; }
}
