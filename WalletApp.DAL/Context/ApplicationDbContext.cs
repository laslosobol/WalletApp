using Microsoft.EntityFrameworkCore;
using WalletApp.DAL.Entities;

namespace WalletApp.DAL.Context;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => base.OnModelCreating(modelBuilder);
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {}
}