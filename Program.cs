using eShop.Catalog.Data;
using eShop.Catalog.Entities;
using eShop.Catalog.Extensions;
using eShop.Catalog.Interfaces;
using eShop.Catalog.Middleware;
using eShop.Catalog.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StoreContext>(x => x.UseSqlite(connectionString));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}




app.MapGet("/api/products", async (IProductService productService) =>
{
    var products = await productService.GetAllProductsAsync();
    return Results.Ok(products);
});

app.MapGet("/api/products/{id}", async (IProductService productService, int id) =>
{
    var product = await productService.GetProductByIdAsync(id);
    
    return Results.Ok(product);
});

app.MapPost("/api/products", async (IProductService productService, Product product) =>
{
    await productService.AddProductAsync(product);
    return Results.Ok();
});

app.MapPut("/api/products/{id}", async (IProductService productService, int id, Product updatedProduct) =>
{
    try
    {
        await productService.UpdateProductAsync(id, updatedProduct);
        return Results.Ok();
    }
    catch (KeyNotFoundException)
    {
        return Results.NotFound();
    }
});

app.MapDelete("/api/products/{id}", async (IProductService productService, int id) =>
{
    try
    {
        await productService.DeleteProductAsync(id);
        return Results.Ok();
   }
   catch (KeyNotFoundException)
    {
    return Results.NotFound();
    }
});


using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(opt => {
    opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000");
});

app.Run();
