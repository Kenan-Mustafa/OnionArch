using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x=> new {x.ProductId , x.CategoryId});

            builder.HasOne(x=>x.Product)
                .WithMany(px=>px.ProductCategories)
                .HasForeignKey(x=>x.ProductId).OnDelete(deleteBehavior:DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category)
                .WithMany(px => px.ProductCategories)
                .HasForeignKey(x => x.CategoryId).OnDelete(deleteBehavior: DeleteBehavior.Cascade);

        }
    }
}
