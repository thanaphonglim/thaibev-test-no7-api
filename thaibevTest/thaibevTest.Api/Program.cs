using thaibevTest.Api.Endpoints;
using thaibevTest.Application.Features.Products.CreateProduct;
using thaibevTest.Application.Features.Products.DeleteProduct;
using thaibevTest.Application.Features.Products.GetProducts;
using thaibevTest.Application.Features.Products.SearchProducts;
using thaibevTest.Application.Interfaces;
using thaibevTest.Infrastructure.Data.AppDbContext;
using thaibevTest.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<CreateProductHandler>();
builder.Services.AddScoped<GetProductsHandler>();
builder.Services.AddScoped<SearchProductsHandler>();
builder.Services.AddScoped<DeleteProductHandler>();

//builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("thaibevTestDb"));
var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();
builder.Services.AddSingleton(connection);
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(connection);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseCors("AllowAll");
app.UseSwagger();
app.UseSwaggerUI();

app.MapGroup("/api/products").MapProductEndpoints();
app.Run();
