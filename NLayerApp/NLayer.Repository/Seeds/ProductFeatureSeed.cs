using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    public class ProductFeatureSeed : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {

            builder.HasData(new ProductFeature
            {
                Id = 1,
                ProductId= 1,
                Color = "Red",
                Height=100,
                Width=200,
            },
            new ProductFeature
            {
                Id = 2,
                ProductId = 2,
                Color = "Blue",
                Height = 200,
                Width = 150,
            },
            new ProductFeature
            {
                Id = 3,
                ProductId = 3,
                Color = "Black",
                Width = 300,
                Height= 40,
            });
        }
    }
}
