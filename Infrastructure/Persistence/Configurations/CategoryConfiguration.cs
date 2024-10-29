using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(256);
        builder.HasData(
            new Category() { Id = 1, Name = "Elektrik", Priority = 1, ParentId = 0, CreatedDate = DateTime.Now },
            new Category() { Id = 2, Name = "Moda", Priority = 2, ParentId = 0, CreatedDate = DateTime.Now },
            new Category() { Id = 3, Name = "Bilgisayar", Priority = 1, ParentId = 1, CreatedDate = DateTime.Now },
            new Category() { Id = 4, Name = "Kadın", Priority = 1, ParentId = 2, CreatedDate = DateTime.Now }
            );
    }
}
