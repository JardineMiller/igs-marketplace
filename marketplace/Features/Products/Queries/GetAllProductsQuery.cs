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
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductListResponseModel>> { }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductListResponseModel>>
    {
        private readonly ApplicationDbContext context;

        public GetAllProductsQueryHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ProductListResponseModel>> Handle(GetAllProductsQuery request,
            CancellationToken cancellationToken)
        {
            return await context.Products
                .AsNoTracking()
                .Select(x => new ProductListResponseModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    Price = x.Price
                }).ToListAsync(cancellationToken);
        }
    }
}
