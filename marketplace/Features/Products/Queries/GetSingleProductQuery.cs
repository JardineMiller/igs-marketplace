using System.Threading;
using System.Threading.Tasks;
using marketplace.Data;
using marketplace.Data.Models;
using marketplace.Features.Products.Models;
using marketplace.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace marketplace.Features.Products.Queries
{
    public class GetSingleProductQuery : IRequest<ProductResponseModel>
    {
        public int Id { get; set; }
    }

    public class GetSingleProductQueryHandler : IRequestHandler<GetSingleProductQuery, ProductResponseModel>
    {
        private readonly ApplicationDbContext context;

        public GetSingleProductQueryHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ProductResponseModel> Handle(GetSingleProductQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            return new ProductResponseModel
            {
                Id = entity.Id,
                Code = entity.Id.ToString("000"),
                Name = entity.Name,
                Price = entity.Price.ToString("F")
            };
        }
    }
}
