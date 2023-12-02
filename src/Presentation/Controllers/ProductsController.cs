using Application.useCases.Product.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product = Domain.Entities.Product;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> AddAsync(string name)
        {
            var productCreateCommand = new ProductCreateCommand()
            {
                Name = name
            };

            var product = await _mediator.Send(productCreateCommand);

            return Ok(product);
        }
    }
}
