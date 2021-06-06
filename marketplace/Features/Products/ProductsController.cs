using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.Features.Products.Commands;
using marketplace.Features.Products.Models;
using marketplace.Features.Products.Queries;
using Microsoft.AspNetCore.Mvc;

namespace marketplace.Features.Products
{
    public class ProductsController : ApiController
    {
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<ProductResponseModel>>> GetAll()
        {
            var query = new GetAllProductsQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("product/{id:int}")]
        public async Task<ActionResult<ProductResponseModel>> GetById(string code)
        {
            var query = new GetSingleProductQuery {Code = code};
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("product")]
        public async Task<ActionResult> Create([FromForm] CreateProductCommand command)
        {
            var id = await Mediator.Send(command);
            return Created(nameof(Create), id);
        }
    }
}
