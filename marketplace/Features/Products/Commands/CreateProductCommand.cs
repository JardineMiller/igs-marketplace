using System.Threading;
using System.Threading.Tasks;
using marketplace.Data;
using marketplace.Data.Models;
using marketplace.Features.Products.Helpers;
using MediatR;

namespace marketplace.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly ApplicationDbContext context;

        public CreateProductCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = ProductPriceHelpers.RoundToTwoPlaces(request.Price)
            };

            context.Add(product);
            await context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
