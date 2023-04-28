
using eShop.Catalog.Entities;

namespace eShop.Catalog.Interfaces;
public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task AddProductAsync(Product product);
    Task UpdateProductAsync(int id, Product updatedProduct);
    Task DeleteProductAsync(int id);
}