using System.Reflection;
using InfoKeeper.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoKeeper.Infrastructure.Database.MySQL;

public class InfoKeeperContext : DbContext
{
    public DbSet<Tag> Tags { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}