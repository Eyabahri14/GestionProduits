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
    public class FactureConfiguration : IEntityTypeConfiguration<Facture>
    {

        //Table porteuse de donnés config
        public void Configure(EntityTypeBuilder<Facture> builder)
        {
            builder.HasKey(t => new
            {
                t.ClientFK,
                t.ProductFK,
                t.DateAchat
            });

            builder.HasOne(facture => facture.Client)
                .WithMany(client => client.Factures)
                .HasForeignKey(facture => facture.ClientFK);

            builder.HasOne(facture => facture.Product)
               .WithMany(client => client.Factures)
               .HasForeignKey(facture => facture.ProductFK);
        }
    }
}
