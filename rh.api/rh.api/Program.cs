using rh.api.Infra.Interfaces;
using rh.api.Services.Interface;
using rh.api.Services.Services;
using Microsoft.EntityFrameworkCore; 
using System.Data;
using System.Data.SqlClient;
using rh.api.Infra.Context;
using rh.api.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IDbConnection>(provider =>
{
    SqlConnection connection = new SqlConnection(connectionString);
    connection.Open();
    return connection;
});


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)); 

#region Services
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IColaboradorService, ColaboradorService>(); 
#endregion Services

#region Repositories
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>(); // Certifique-se de registrar a interface e implementação corretamente
#endregion Repositories

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

