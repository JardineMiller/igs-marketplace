namespace marketplace.Data.Repositories
{
    public interface IProductRepository
    {

    }

    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}
