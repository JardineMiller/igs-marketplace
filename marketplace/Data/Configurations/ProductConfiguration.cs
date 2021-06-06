using System;
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

            builder.HasData(
                new Product
                {
                    Id = 1,
                    Code = "001",
                    Name = "Lavender heart",
                    CreatedOn = DateTimeOffset.UtcNow,
                    Price = (decimal) 9.25
                },
                new Product
                {
                    Id = 2,
                    Code = "Personalised cufflinks",
                    Name = "Product 2",
                    CreatedOn = DateTimeOffset.UtcNow,
                    Price = (decimal) 45.00
                },
                new Product
                {
                    Id = 3,
                    Code = "003",
                    Name = "Kids T-shirt",
                    CreatedOn = DateTimeOffset.UtcNow,
                    Price = (decimal) 19.95
                }
            );
        }
    }
}
