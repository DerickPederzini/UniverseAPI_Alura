using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs;

public class ReadAddressDTO
{
    public int Id { get; set; }
    public string MyProperty { get; set; }
    public int Number { get; set; }
}
