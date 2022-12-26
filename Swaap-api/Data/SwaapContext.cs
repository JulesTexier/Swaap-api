
using Microsoft.EntityFrameworkCore;
using Swaap_api.Models;

namespace Swaap_api.Models;

public class SwaapContext : DbContext
{
    public SwaapContext(DbContextOptions<SwaapContext> options)
        : base(options)
    {
    }

    public DbSet<CatalogItem> CatalogItems { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;


}