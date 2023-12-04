using MediatR;

namespace Application.useCases.Product.Commands
{
    public class ProductCreateCommand : IRequest<Domain.Entities.Product>
    {
        public string Name { get; set; }
    }
}
