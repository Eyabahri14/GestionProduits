using App.ApplicationCore.Domain;
using App.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public class Context : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<Chemical> Chemicals { get; set; }
        public DbSet<Biological> Biologicals { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Facture> Factures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseLazyLoadingProxies().
                UseSqlServer(this.GetJsonConnectionString("appsettings.json"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Entity Configuration 
            //Many To Many Configuration 
            //modelBuilder.Entity<Product>().
            //  HasMany(prod => prod.Providers)
            //   .WithMany(prov => prov.Products)
            //   .UsingEntity(t => {
            //       t.ToTable("MyProvidings");
            //   });
            //One To Many Configuration 
            // modelBuilder.Entity<Product>().
            //  HasOne(prod => prod.Category)
            // .WithMany(categ => categ.Products)
            // .HasForeignKey(prod => prod.CategoryFK)
            // .OnDelete(DeleteBehavior.ClientSetNull);  //Désactiver la cascade 

            // modelBuilder.Entity<Category>()
            //   .ToTable("MyCategories");

            // modelBuilder.Entity<Category>().
            //    HasKey(c => c.CategoryId);


            //Property Configuration 
            // modelBuilder.Entity<Category>().
            //   Property(c => c.Name)
            //  .IsRequired()
            //  .HasDefaultValue("Categorie")
            //  .HasMaxLength(50);



            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new FactureConfiguration());

            // modelBuilder.Entity<Chemical>().ToTable("MyChemicals");
            //  modelBuilder.Entity<Biological>().ToTable("MyBiologicals");


        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // Pre-convention model configuration goes here
            //    configurationBuilder
            //        .Properties<string>()
            //        .HaveMaxLength(50);
            //configurationBuilder
            //    .Properties<decimal>()
            //        .HavePrecision(8,3); //8 chiffres avant la virugule et 3 chiffres apres la virgule
            // configurationBuilder
            //  .Properties<DateTime>()
            //  .HaveColumnType("date");



        }
    }
}
