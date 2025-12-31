using System.Security.Cryptography;
using System.Text;
using gLiter.Core.Constants;
using gLiter.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace gLiter.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Service> Services => Set<Service>();
    public DbSet<Station> Stations => Set<Station>();
    public DbSet<FuelPrice> FuelPrices => Set<FuelPrice>();
    public DbSet<News> News => Set<News>();
    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<GalleryImage> GalleryImages => Set<GalleryImage>();
    public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();
    public DbSet<AdminUser> AdminUsers => Set<AdminUser>();
    public DbSet<HeroSection> HeroSections => Set<HeroSection>();
    public DbSet<TransportRequest> TransportRequests => Set<TransportRequest>();
    public DbSet<TransportRequestImage> TransportRequestImages => Set<TransportRequestImage>();
    public DbSet<SuccessPartner> SuccessPartners => Set<SuccessPartner>();
    public DbSet<FleetVehicle> FleetVehicles => Set<FleetVehicle>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AdminUser>()
            .HasIndex(a => a.Username)
            .IsUnique();

        modelBuilder.Entity<AdminUser>()
            .HasIndex(a => a.Email)
            .IsUnique();

        modelBuilder.Entity<GalleryImage>()
            .Property(g => g.ImageUrl)
            .HasMaxLength(512);

        modelBuilder.Entity<ContactMessage>()
            .Property(c => c.Email)
            .HasMaxLength(256);

        // Ensure Price decimal precision to avoid truncation issues on SQL Server
        modelBuilder.Entity<FuelPrice>()
            .Property(fp => fp.Price)
            .HasPrecision(18, 2);

        var (hash, salt) = CreatePasswordHash("Abcde3456$");
        modelBuilder.Entity<AdminUser>().HasData(
            new AdminUser
            {
                Id = 1,
                FullName = "Super Admin",
                Email = "superadmin@g-liter.com",
                Username = "superadmin",
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = AdminRoles.SuperAdmin,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new AdminUser
            {
                Id = 20,
                FullName = "Customer Service",
                Email = "cs@g-liter.com",
                Username = "cs_admin",
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = AdminRoles.CustomerService,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            },
            new AdminUser
            {
                Id = 30,
                FullName = "HR Manager",
                Email = "hr@g-liter.com",
                Username = "hr_admin",
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = AdminRoles.HR,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            }
        );
    }

    private static (byte[] hash, byte[] salt) CreatePasswordHash(string password)
    {
        using var hmac = new HMACSHA512();
        var salt = hmac.Key;
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return (hash, salt);
    }
}
