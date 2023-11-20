using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Page> Pages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/DNP3v2.db");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Page>().HasKey(p => p.Id);
        builder.Entity<User>().HasKey(u => u.Id);
    }
    
}