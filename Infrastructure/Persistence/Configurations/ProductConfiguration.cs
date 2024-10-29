using Bogus;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        Faker faker = new Faker("tr");
        builder.HasData(
            new Product() { Id = 1 , Title = faker.Commerce.ProductName() , Description = faker.Commerce.ProductDescription(), BrandId = 1, Discount = faker.Random.Decimal(0,10),Price= faker.Finance.Amount(10,10000) }, 
            new Product() { Id = 2, Title = faker.Commerce.ProductName(), Description = faker.Commerce.ProductDescription(), BrandId = 3, Discount = faker.Random.Decimal(0, 10), Price = faker.Finance.Amount(10, 10000) },
            new Product() { Id = 3, Title = faker.Commerce.ProductName(), Description = faker.Commerce.ProductDescription(), BrandId = 3, Discount = faker.Random.Decimal(0, 10), Price = faker.Finance.Amount(10, 10000) }
            );
    }
}
