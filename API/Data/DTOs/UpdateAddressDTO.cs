using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs;

public class UpdateAddressDTO
{
    [Required]
    public string MyProperty { get; set; }
    public int Number { get; set; }
}
