using App.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Many To Many Configuration entre Product et Provider
            builder.HasMany(prod => prod.Providers)
                .WithMany(prov => prov.Products)
                .UsingEntity(t => {
                    t.ToTable("MyProvidings");
                });
            //1 To Many Configuration entre Product et Category 
            builder.HasOne(prod => prod.Category)
                .WithMany(categ => categ.Products)
                .HasForeignKey(prod => prod.CategoryFK)
                .OnDelete(DeleteBehavior.ClientSetNull);  //Désactiver la cascade 

            //Table Per Hierarchy Configurations
            builder.HasDiscriminator<string>("ProductType")
              .HasValue<Chemical>("Chemical")
            .HasValue<Biological>("Biological")
             .HasValue<Product>("Product");//default value

            //builder.HasDiscriminator<int>("IsBiological")
            //    .HasValue<Chemical>(0)
            //   .HasValue<Biological>(1)
            //   .HasValue<Product>(0);//default value

        }
    }
}
