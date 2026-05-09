using Microsoft.EntityFrameworkCore;
using GuitarWorld.Models;

namespace GuitarWorld.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
}