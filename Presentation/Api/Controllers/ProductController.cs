using Application.Features.Products.Command.CreateProduct;
using Application.Features.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProdcuts()
        {
            var data = await mediator.Send(new GetAllProductsQueryRequest());
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProdcut(CreateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
