using Microsoft.EntityFrameworkCore;
using rh.api.Domain;

namespace rh.api.Infra.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>opts) : base(opts)
    {
        
    }
    public DbSet<Colaborador> ? Colaboradores { get; set; }
    public DbSet<Empresa> ? Empresas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //base.OnModelCreating(modelBuilder);

        //// Exemplo de mapeamento
        //modelBuilder.Entity<Colaborador>()
        //    .ToTable("COLABORADORES")
        //    .HasKey(c => c.ColaboradorID);
    }
}
