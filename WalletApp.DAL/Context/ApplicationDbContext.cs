using Microsoft.EntityFrameworkCore;
using WalletApp.DAL.Entities;

namespace WalletApp.DAL.Context;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<User> Customers { get; set; }
    public DbSet<Card> Couriers { get; set; }
    public DbSet<Transaction> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => base.OnModelCreating(modelBuilder);
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testTask;User Id=postgres;Password=sobol;");

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}