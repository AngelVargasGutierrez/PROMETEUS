using ClienteAPI.Data;
using Microsoft.EntityFrameworkCore;
using Prometheus;
using HealthChecks.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Configuración para escuchar en el puerto 80 en producción (Docker)
if (builder.Environment.IsProduction())
{
    builder.WebHost.ConfigureKestrel(serverOptions =>
    {
        serverOptions.ListenAnyIP(80); // HTTP
    });
}

// Add services to the container.
builder.Services.AddDbContext<BdClientesContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ClienteDB")));

builder.Services.AddControllers();

// HealthChecks para la base de datos
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("ClienteDB"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMetricServer();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseHttpMetrics();
app.MapControllers();

// Exponer endpoint de health
app.MapHealthChecks("/health");

app.Run();
