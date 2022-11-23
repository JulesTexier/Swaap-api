
using Microsoft.EntityFrameworkCore;
using SwaapApi.Models;

namespace SwaapApi.Models;

public class SwaapContext : DbContext
{
    public SwaapContext(DbContextOptions<SwaapContext> options)
        : base(options)
    {
    }

    public DbSet<CatalogProduct> CatalogProducts { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<SwaapApi.Models.Category> Category { get; set; } = default!;
}