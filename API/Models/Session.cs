using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Session
    {
        //This class is refering to sessions to visit the celestial bodies listed

        //one celestial body can have multiple sessions
        [Required]
        public int CelestialId { get; set; }
        public virtual Celestial Celestial { get; set; }

        [Required]
        public int AddressId { get; set; }
        public virtual Address Addresses { get; set; }



    }
}
