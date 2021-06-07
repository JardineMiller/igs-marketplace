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
        /// <summary>
        /// Fetch all un-deleted Products
        /// </summary>
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<ProductResponseModel>>> GetAll()
        {
            var query = new GetAllProductsQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Fetch a single, un-deleted Product by its database id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("product/{id:int}")]
        public async Task<ActionResult<ProductResponseModel>> GetById(int id)
        {
            var query = new GetSingleProductQuery {Id = id};
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="command"></param>
        [HttpPost("product")]
        public async Task<ActionResult> Create([FromForm] CreateProductCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        /// <summary>
        /// Update an existing product
        /// </summary>
        /// <param name="command"></param>
        /// <param name="id"></param>
        [HttpPut("product/{id:int}")]
        public async Task<ActionResult> Update([FromForm] UpdateProductCommand command, int id)
        {
            command.Id = id;
            await Mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Delete an existing product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("product/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand {Id = id};
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
