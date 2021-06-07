using marketplace.Data.Models.Base;

namespace marketplace.Data.Models
{
    public class Product : DeleteableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
