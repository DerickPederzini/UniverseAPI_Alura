using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Session
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int CelestialId { get; set; }
        public virtual Celestial Celestial { get; set; }

    }
}
