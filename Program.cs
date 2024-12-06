using Microsoft.EntityFrameworkCore;
using MediatR;
using InventarioPerecederos.Infrastructure.Data;
using InventarioPerecederos.Application.Interfaces;
using InventarioPerecederos.Infrastructure.Repositories;  // Asegúrate de agregar esta referencia
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura los servicios para usar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200")  // URL de tu frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
// Inyección de dependencias
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar la base de datos en memoria (sin necesidad de conexión a SQL Server)
// builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InventarioPerecederosDB"));

// Registra los servicios de MediatR para el patrón CQRS
builder.Services.AddMediatR(typeof(Program).Assembly);  // Registra todos los handlers de MediatR desde el ensamblado actual

// Registra AutoMapper para mapear entre DTOs y entidades
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Registra las implementaciones de los repositorios en la capa de infraestructura
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IEntradaRepository, EntradaRepository>();
builder.Services.AddScoped<ISalidaRepository, SalidaRepository>();

// Registra Swagger para documentación de la API
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Inventario Perecederos",
        Version = "v1",
        Description = "API para gestionar inventarios de productos perecederos"
    });
});

// Registra los controladores de la API
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowLocalhost");
// Configuración de middleware
app.UseHttpsRedirection();

// Mapea los controladores
app.MapControllers();

app.Run();
