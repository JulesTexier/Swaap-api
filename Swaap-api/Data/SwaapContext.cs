
using Microsoft.EntityFrameworkCore;
using Swaap_api.Models;

namespace Swaap_api.Models;

public class SwaapContext : DbContext
{
    public SwaapContext(DbContextOptions<SwaapContext> options)
        : base(options)
    {
    }

    public DbSet<Catalog> Catalogs { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Swaap_api.Models.User> Users { get; set; } = null!;

}