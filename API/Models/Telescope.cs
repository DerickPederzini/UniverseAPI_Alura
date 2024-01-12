using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Telescope
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public string Name { get; set; }

    //one celestial can have multiple telescopes looking at it at the same time, but a telescope must be looking at one or none celestials
    public int AddressId { get; set; }
    public virtual Address address { get; set; }
    public int? CelestialId { get; set; }
    public virtual Celestial Celestial {  get; set; }

}
