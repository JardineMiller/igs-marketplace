using marketplace.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static marketplace.Data.ValidationConstants.Product;

namespace marketplace.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasQueryFilter(p => !p.IsDeleted);

            builder
                .Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(MaxCodeLength);

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,4)");
        }
    }
}
