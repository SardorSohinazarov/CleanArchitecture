using Application.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ProductService:IProductService
    {
        private readonly IApplicationDbContext _context;

        public ProductService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async ValueTask<Product> AddProductAsync(Product product)
        {
            var entry = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<List<Product>> GetProductsAsync()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }
    }
}
