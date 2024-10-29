using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace Persistence.Configurations;

public class DetailConfiguration : IEntityTypeConfiguration<Detail>
{
    public void Configure(EntityTypeBuilder<Detail> builder)
    {
        Faker faker = new Faker("tr");
        builder.HasData(
            new Detail() { Id = 1, Title = faker.Lorem.Sentence(1), Description = faker.Lorem.Sentence(5), CategoryId = 1, CreatedDate = DateTime.Now, IsDeleted = false },
            new Detail() { Id = 2, Title = faker.Lorem.Sentence(2), Description = faker.Lorem.Sentence(5), CategoryId = 3, CreatedDate = DateTime.Now, IsDeleted = true },
            new Detail() { Id = 3, Title = faker.Lorem.Sentence(1), Description = faker.Lorem.Sentence(5), CategoryId = 4, CreatedDate = DateTime.Now, IsDeleted = false }
            );
    }
}