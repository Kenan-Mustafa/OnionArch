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

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(256);

        Faker faker = new("tr");

        builder.HasData(
            new Brand() { Name = faker.Commerce.Department(), Id = 1, IsDeleted = false, CreatedDate = DateTime.Now },
            new Brand() { Name = faker.Commerce.Department(), Id = 2, IsDeleted = false, CreatedDate = DateTime.Now },
            new Brand() { Name = faker.Commerce.Department(), Id = 3, IsDeleted = false, CreatedDate = DateTime.Now },
            new Brand() { Name = faker.Commerce.Department(), Id = 4, IsDeleted = true, CreatedDate = DateTime.Now }
            );

    }
}
