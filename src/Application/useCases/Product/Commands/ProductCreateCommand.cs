﻿using Application.Abstraction;
using MediatR;

namespace Application.useCases.Product.Commands
{
    public class ProductCreateCommand:IRequest<Domain.Entities.Product>
    {
        public string Name { get; set; }
    }

    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand,Domain.Entities.Product>
    {
        private readonly IApplicationDbContext _context;

        public ProductCreateCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        async Task<Domain.Entities.Product> IRequestHandler<ProductCreateCommand, Domain.Entities.Product>.Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            //nima ish qiladi

            var entry = await _context.Products.AddAsync(new Domain.Entities.Product()
            {
                Name = request.Name,
            });

            await _context.SaveChangesAsync(cancellationToken);

            return entry.Entity;
        }
    }
}
