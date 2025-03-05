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

    #region Primeira Questão
    public DbSet<Funcionario> Funcionarios { get; set; }
    #endregion
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

       
    }
}
