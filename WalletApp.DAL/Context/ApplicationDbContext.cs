using Microsoft.EntityFrameworkCore;
using WalletApp.DAL.Entities;

namespace WalletApp.DAL.Context;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<User> Customers { get; set; }
    public DbSet<Card> Couriers { get; set; }
    public DbSet<Transaction> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}