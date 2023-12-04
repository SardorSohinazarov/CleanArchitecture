using Application.Abstraction;
using Application.Notifications;
using Application.useCases.Product.Commands;
using MediatR;

namespace Application.useCases.Product.CommandHandlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Domain.Entities.Product>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public ProductCreateCommandHandler(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        async Task<Domain.Entities.Product> IRequestHandler<ProductCreateCommand, Domain.Entities.Product>.Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            //nima ish qiladi
            var entry = await _context.Products.AddAsync(new Domain.Entities.Product()
            {
                Name = request.Name,
            });

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new ProductCreateNotification()
            {
                Product = entry.Entity
            });

            return entry.Entity;
        }
    }
}
