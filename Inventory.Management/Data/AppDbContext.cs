using Microsoft.EntityFrameworkCore;
using Inventory.Management.Models;

namespace Inventory.Management.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<InventoryItem> Items => Set<InventoryItem>();
}