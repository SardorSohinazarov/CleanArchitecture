using Microsoft.EntityFrameworkCore;

namespace Application.Abstraction
{
    public interface IApplicationDbContext
    {
        public DbSet<Domain.Entities.Product> Products { get; set; }
        public ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
