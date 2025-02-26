using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RHAPi.Infra.Context;
using RHAPi.Infra.Interfaces;
using RHAPi.Infra.Repositories;
using RHAPi.Service.Interfaces;
using RHAPi.Service.Service;
using RHAPI.Infra.Interfaces;
using RHAPI.Infra.Repositories;
using RHAPI.Service.Interfaces;
using RHAPI.Service.Service;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

#region dapper
builder.Services.AddScoped<IDbConnection>(provider => 
{
    SqlConnection connection = new(connectionString);    
    connection.Open();
    return connection;
});
#endregion

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

#region Services
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IColaboradorService, ColaboradorService>();
#endregion

#region Repository
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepositoy>();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRespository>();
#endregion

builder.Services.AddControllers();

// Add services to the container.
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

