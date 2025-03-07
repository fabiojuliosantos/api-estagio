using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RH.API.Infra.Context;
using RH.API.Infra.Interfaces;
using RH.API.Infra.Repositories;
using RH.API.Services.Interface;
using RH.API.Services.Services;
using System;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura��es de servi�os
builder.Services.AddAutoMapper(typeof(Program));

// Configura��o do banco de dados
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IDbConnection>(provider =>
{
    SqlConnection connection = new SqlConnection(connectionString);
    connection.Open();
    return connection;
});

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

#region Services
//builder.Services.AddScoped<IEmpresaService, EmpresaService>();
//builder.Services.AddScoped<IColaboradorService, ColaboradorService>();
builder.Services.AddSingleton<IFuncionarioService, FuncionarioService>();
builder.Services.AddSingleton<IbcomService, BcomService>();
builder.Services.AddSingleton<IprodutoService, ProdutosService>();
builder.Services.AddSingleton<IEstudanteService, EstudanteService>();
builder.Services.AddSingleton<ILivroService, LivroService>();
#endregion Services

#region Repositories
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
#endregion Repositories

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build da aplica��o
var app = builder.Build();

// Configura��es do pipeline de requisi��es
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Executa a aplica��o
app.Run();