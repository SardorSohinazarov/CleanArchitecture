using Application.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext:DbContext,IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Product> Products { get; set; }

        async ValueTask<int> IApplicationDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
