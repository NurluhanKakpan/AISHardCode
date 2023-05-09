using Microsoft.EntityFrameworkCore;
using techTask2.Models;

namespace techTask2.Data;

public class DataContext : DbContext
{
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    public DbSet<Owner>? Owners { get; set; }
    public DbSet<Application>? Applications { get; set; }
    public DbSet<Transport> Transports { get; set; }
    public DbSet<Inspector> Inspectors { get; set; }
    public DbSet<Srts> Srts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Owner>().HasMany(e => e.Applications).WithOne(e => e.Owner)
            .HasForeignKey(e => e.OwnerId).IsRequired();
        modelBuilder.Entity<Transport>().HasMany(e => e.Applications).WithOne(e => e.Transport)
            .HasForeignKey(e => e.TransportId).IsRequired();
        modelBuilder.Entity<Owner>().HasMany(e => e.Transports).WithOne(e => e.Owner).HasForeignKey(e => e.OwnerId)
            .IsRequired();
        modelBuilder.Entity<Owner>().HasMany(e => e.OwnerSrts).WithOne(e => e.Owner).HasForeignKey(e => e.OwnerId)
            .IsRequired();
        modelBuilder.Entity<Transport>().HasOne(e => e.Srts).WithOne(e => e.Transport)
            .HasForeignKey<Srts>(e => e.TransportId).IsRequired();


    }
}