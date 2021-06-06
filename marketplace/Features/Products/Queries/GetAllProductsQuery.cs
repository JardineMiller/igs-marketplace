using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using marketplace.Data;
using marketplace.Features.Products.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace marketplace.Features.Products.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductResponseModel>> { }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductResponseModel>>
    {
        private readonly ApplicationDbContext context;

        public GetAllProductsQueryHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ProductResponseModel>> Handle(GetAllProductsQuery request,
            CancellationToken cancellationToken)
        {
            return await context.Products
                .AsNoTracking()
                .Select(x => new ProductResponseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    Price = x.Price
                }).ToListAsync(cancellationToken);
        }
    }
}
