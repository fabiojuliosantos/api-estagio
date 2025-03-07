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

    //Segunda Questao
    public DbSet<Banco>? Bancos { get; set; }

    //Terceira Questao

    public DbSet<Produto> Produtos { get; set; }

    //Quarta Questao
    public DbSet<Estudante> Estudantes { get; set; }

    //Quarta Questao
    //public DbSet<Biblioteca> Bibliotecas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
     

    }
}
