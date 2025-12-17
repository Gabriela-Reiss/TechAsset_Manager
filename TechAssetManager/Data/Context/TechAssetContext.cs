using Microsoft.EntityFrameworkCore;
using TechAssetManager.Models;

namespace TechAssetManager.Data.Context;

public class TechAssetContext : DbContext
{

    public TechAssetContext(DbContextOptions<TechAssetContext> options) : base(options)
    {

    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Ativo> Ativos { get; set; }
}
