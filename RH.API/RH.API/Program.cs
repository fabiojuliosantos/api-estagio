using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RH.API.Infra.Context;
using RH.API.Infra.Interfaces;
using RH.API.Infra.Repositories;
using RH.API.Services.Interface;
using RH.API.Services.Interface.TestePOO;
using RH.API.Services.Services;
using RH.API.Services.Services.TestePOO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); // Configurando a string de conexão

builder.Services.AddScoped<IDbConnection>(provider => // Provedor abre a conexão abaixo
{
    // Estância do banco
    SqlConnection connection = new(connectionString);
    connection.Open();
    return connection; // Retornando a conexão criada
});

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

// Fazendo com que o programa enxergue as interfaces e suas classes (Injeção)
#region Services
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IColaboradorService, ColaboradorService>();
builder.Services.AddSingleton<IFuncionarioService, FuncionarioService>();
builder.Services.AddSingleton<IBcomService, BcomService>();
builder.Services.AddSingleton<IProdutoService, ProdutoService>();
builder.Services.AddSingleton<IEstudanteService, EstudanteService>();
#endregion

#region Repositories
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
#endregion

// Adicionando o automapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
