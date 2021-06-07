using System.Threading;
using System.Threading.Tasks;
using marketplace.Data;
using marketplace.Data.Models;
using marketplace.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace marketplace.Features.Products.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly ApplicationDbContext context;

        public DeleteProductCommandHandler(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Products
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            context.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
