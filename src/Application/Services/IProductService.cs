using Domain.Entities;

namespace Application.Services
{
    public interface IProductService
    {
        public ValueTask<Product> AddProductAsync(Product product);
        public ValueTask<List<Product>> GetProductsAsync();
    }
}
