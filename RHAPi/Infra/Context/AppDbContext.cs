using Microsoft.EntityFrameworkCore;
using RHAPi.Domain;

namespace RHAPi.Infra.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) {}

    public DbSet<Empresa> ? Empresas { get; set; }
    public DbSet<Colaborador> ? Colaboradores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}