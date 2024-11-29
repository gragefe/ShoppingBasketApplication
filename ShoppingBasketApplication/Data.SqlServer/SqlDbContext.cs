namespace Data.SqlServer;

using Data.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;

public class SqlDbContext : DbContext
{
    public DbSet<Item> Items { get; set; }

    public DbSet<Basket> Baskets { get; set; }

    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}