using DeliveryApp.API.Interfaces;
using DeliveryApp.API.Repositories;
using JuanK.Persintence.EF;
using JuanK.Persintence.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddScoped<IEntityRepository<Producto, Guid>, EntityRepository<Producto, Guid>>();
builder.Services.AddScoped<IEntityRepository<Tienda, Guid>, EntityRepository<Tienda, Guid>>();
builder.Services.AddScoped<IEntityRepository<Categoria, Guid>, EntityRepository<Categoria, Guid>>();

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
