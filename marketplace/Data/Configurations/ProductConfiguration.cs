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
                    Code = "Product-001",
                    Name = "Product 1",
                    CreatedOn = DateTimeOffset.UtcNow,
                    Price = (decimal) 10.25
                },
                new Product
                {
                    Id = 2,
                    Code = "Product-002",
                    Name = "Product 2",
                    CreatedOn = DateTimeOffset.UtcNow,
                    Price = (decimal) 45.00
                },
                new Product
                {
                    Id = 3,
                    Code = "Product-003",
                    Name = "Product 3",
                    CreatedOn = DateTimeOffset.UtcNow,
                    Price = (decimal) 9.25
                },
                new Product
                {
                    Id = 4,
                    Code = "Product-004",
                    Name = "Product 4",
                    CreatedOn = DateTimeOffset.UtcNow,
                    Price = (decimal) 3.99
                }
            );
        }
    }
}
