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
        public async Task<ActionResult<ProductResponseModel>> GetById(int id)
        {
            var query = new GetSingleProductQuery {Id = id};
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("product")]
        public async Task<ActionResult> Create([FromForm] CreateProductCommand command)
        {
            var id = await Mediator.Send(command);
            return Created(nameof(Create), id);
        }

        [HttpPut("product")]
        public async Task<ActionResult> Update([FromForm] UpdateProductCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
