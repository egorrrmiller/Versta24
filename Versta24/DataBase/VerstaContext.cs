using Microsoft.EntityFrameworkCore;
using Versta24.Models;

namespace Versta24.DataBase;

public sealed class VerstaContext : DbContext
{
    public VerstaContext(DbContextOptions<VerstaContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<OrderModel> Order { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderModel>()
            .Property(id => id.IdCargo)
            .ValueGeneratedOnAdd();

        base.OnModelCreating(modelBuilder);
    }
}