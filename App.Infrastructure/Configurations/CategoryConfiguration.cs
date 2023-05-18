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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("MyCategories");//Table Name
           // builder.HasKey(c => c.CategoryId); //Primary Key

            //Property Configurations 
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);



        }
    }
}
