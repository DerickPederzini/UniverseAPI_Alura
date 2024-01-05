using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UniverseContext : DbContext
{
    public UniverseContext(DbContextOptions<UniverseContext> options) : 
        base(options)
    {
        
    }
    public DbSet<Celestial> CelestialBodies { get; set; }

    public DbSet<Telescope> Telescopes { get; set; }
    
    public DbSet<Address> Addresses { get; set; }

    public DbSet<Session> Sessions { get; set; }

}
