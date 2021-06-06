using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using marketplace.Data;
using marketplace.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
                Code = request.Code ?? await GenerateProductCode(cancellationToken),
                Price = request.Price
            };

            context.Add(product);
            await context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }

        private async Task<string> GenerateProductCode(CancellationToken cancellationToken)
        {
            var last = await context.Products
                .OrderBy(x => x.Id)
                .LastOrDefaultAsync(cancellationToken: cancellationToken);

            if (last == null)
            {
                return 1.ToString("000");
            }

            return (last.Id + 1).ToString("000");
        }
    }
}
