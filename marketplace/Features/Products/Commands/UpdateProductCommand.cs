using System.Threading;
using System.Threading.Tasks;
using marketplace.Data;
using marketplace.Data.Models;
using marketplace.Features.Products.Helpers;
using marketplace.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace marketplace.Features.Products.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly ApplicationDbContext context;

        public UpdateProductCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            if (!string.IsNullOrEmpty(request.Name))
            {
                entity.Name = request.Name;
            }

            if (request.Price.HasValue)
            {
                entity.Price = ProductPriceHelpers.RoundToTwoPlaces(request.Price.Value);
            }

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
