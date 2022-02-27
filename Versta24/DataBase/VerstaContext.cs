using Microsoft.EntityFrameworkCore;
using Versta24.Models;

namespace Versta24.DataBase;

public sealed class VerstaContext : DbContext
{
    public VerstaContext()
    {
        Database.EnsureCreated();
    }
    public DbSet<OrderModel> Order { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = order.db");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderModel>()
            .Property(id => id.IdCargo)
            .ValueGeneratedOnAdd();
        
        base.OnModelCreating(modelBuilder);
    }
}