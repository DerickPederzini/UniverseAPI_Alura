using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Celestial
    {
        [Key]
        [Required]

        public int Id { get; set; }

        [Required(ErrorMessage = "The name of the celestial body is required")]
        [StringLength(50, ErrorMessage = "The celestial body must have a name of at maximum 50 characters")]
        public string Name { get; set; }

        [Required (ErrorMessage = "The Classification of the celestial body is required")]
        [StringLength(50, ErrorMessage = "The celestial body must have a Classification")]
        public string Classification { get; set; }

        [Required (ErrorMessage = "The celestial body must emit or not emit light")]
        public bool EmitsLight { get; set; }

        [Required (ErrorMessage = "The Mass of the celestial body is required")]
        [Range (1000, double.PositiveInfinity, ErrorMessage = "The celestial body should have at least 1000T")]
        public double Mass { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Session> Session {get; set; }

        public virtual ICollection<Telescope> Telescope { get; set; }


    }
}
