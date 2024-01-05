using System.ComponentModel.DataAnnotations;

namespace API.Data.DTOs;

public class UpdateUniverseDTO
{

    //this existis so we dont pass directly to the user the settings of our api. things that he does not need to know how works

    [Required(ErrorMessage = "The name of the celestial body is required")]
    [StringLength(50, ErrorMessage = "The celestial body must have a name of at maximum 50 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "The location of the celestial body is required")]
    [StringLength(50, ErrorMessage = "The celestial body must have a lccation of at maximum 50 characters")]
    public string Classification { get; set; }

    [Required(ErrorMessage = "The celestial body must emit or not emit light")]
    public bool EmitsLight { get; set; }

    [Required(ErrorMessage = "The density of the celestial body is required")]
    [Range(1000, double.PositiveInfinity, ErrorMessage = "The celestial body should have at least 1000T")]
    public double Mass { get; set; }

}
