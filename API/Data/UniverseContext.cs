using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UniverseContext : DbContext
{
    public UniverseContext(DbContextOptions<UniverseContext> options) : 
        base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Session>().HasKey(session => new { session.CelestialId, session.AddressId });

        modelBuilder.Entity<Session>().HasOne(session => session.Addresses).WithMany(address => address.Session).HasForeignKey(session => session.AddressId);

        modelBuilder.Entity<Address>().HasOne(address => address.Celestial).WithOne(celestial => celestial.Address).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Address>().HasOne(address => address.Telescope).WithOne(telescope => telescope.address).OnDelete(DeleteBehavior.Restrict);

    }

    public DbSet<Celestial> CelestialBodies { get; set; }

    public DbSet<Telescope> Telescopes { get; set; }
    
    public DbSet<Address> Addresses { get; set; }

    public DbSet<Session> Sessions { get; set; }

}
