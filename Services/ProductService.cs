using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Catalog.Data;
using eShop.Catalog.Entities;
using eShop.Catalog.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.Services;

public class ProductService : IProductService
{
    private readonly StoreContext _dbContext;

    public ProductService(StoreContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _dbContext.Products
        .ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);

        if (product == null)
        {
            throw new KeyNotFoundException($"Product with id {id} not found");
        }

        return product;
    }

    public async Task AddProductAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(int id, Product updatedProduct)
    {
        var product = await _dbContext.Products.FindAsync(id);
        if (product == null)
        {
            throw new KeyNotFoundException($"Product with id {id} not found");
        }

        product.Name = updatedProduct.Name;
        product.IsFeatured = updatedProduct.IsFeatured;
        product.IsTrend = updatedProduct.IsTrend;
        product.IsPopular = updatedProduct.IsPopular;
        product.RegularPrice = updatedProduct.RegularPrice;
        product.SalesPrice = updatedProduct.SalesPrice;
        product.ShortDescription = updatedProduct.ShortDescription;
        product.Description = updatedProduct.Description;
        product.SKU = updatedProduct.SKU;
        product.StockStatus = updatedProduct.StockStatus;
        product.Quantity = updatedProduct.Quantity;


        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        if (product == null)
        {
            throw new KeyNotFoundException($"Product with id {id} not found");
        }

        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
    }
}