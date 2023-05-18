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
    public class AddressConfiguration : IEntityTypeConfiguration<Chemical>
    {
        public void Configure(EntityTypeBuilder<Chemical> builder)
        {
            //Configuration Type Complexe
            builder.OwnsOne(p => p.Address, builder =>
            {
                builder.Property(a => a.StreetAddress).IsRequired().HasMaxLength(30);
                builder.Property(a => a.City).IsRequired().HasMaxLength(30);
            });


        }

    }
}
