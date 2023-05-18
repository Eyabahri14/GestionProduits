using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.ApplicationCore.Domain
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Ce champs est obligatoire")]
        [StringLength(25, ErrorMessage = "le nom ne doit pas dépasser 25 caractéres ")]
        [MaxLength(50)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [DataType(DataType.Date)] //Valid Date
        [Display(Name = "Production Date")]  //Displayed as "Production Date " 
        public DateTime? DateProd { get; set; }

        [ForeignKey("CategoryFK")]
        public virtual Category? Category { get; set; }

        //[ForeignKey("Category")]
        public int? CategoryFK { get; set; }

        public virtual List<Provider> Providers { get; set; }
        public virtual List<Facture> Factures { get; set; }


       public string? Image { get; set; }
        public Product(string name, string description, double price, int quantity, DateTime dateProd)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            DateProd = dateProd;

        }

        public Product()
        {

        }
        public override string ToString()
        {
            //return $"{nameof(Name)}: {Name}, {nameof(Description)}: {Description}, {nameof(Price)}: {Price}, {nameof(Quantity)}: {Quantity}, {nameof(DateProd)}: {DateProd}";
            return "Name=" + Name + " Description=" + Description + " Price=" + Price + " Quantity=" + Quantity + " Date de production=" + DateProd;
        }

        public virtual void GetMyType()
        {
            Console.WriteLine("Je suis un produit");
        }

    }
}
