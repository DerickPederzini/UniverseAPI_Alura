using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Address
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string MyProperty { get; set; }
    public int Number {  get; set; }

    public virtual Celestial Celestial { get; set; }
    public virtual Telescope Telescope { get; set; }



}
