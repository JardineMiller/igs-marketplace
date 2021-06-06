using System.Collections.Generic;
using System.Threading.Tasks;
using marketplace.Features.Products.Models;
using marketplace.Features.Products.Queries;
using Microsoft.AspNetCore.Mvc;

namespace marketplace.Features.Products
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductListResponseModel>>> GetAll()
        {
            var query = new GetAllProductsQuery();
            var result = await this.Mediator.Send(query);

            return Ok(result);
        }
    }
}
