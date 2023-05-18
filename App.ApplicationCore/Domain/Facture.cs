using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    //table porteuse de donnés 


    // [PrimaryKey(nameof(DateAchat), nameof(ClientFK),nameof(ProductFK))]

    public class Facture
    {
        //[Key]
        //[Column(Order = 0)]
        public DateTime DateAchat { get; set; }

        // [Key]
        //[Column(Order = 1)]
        // [ForeignKey("Client")]
        public string ClientFK { get; set; } //string car CIN 

        //[Key]
        //[Column(Order = 2)]
        //[ForeignKey("Product")]
        public int ProductFK { get; set; }

        public virtual Client Client { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }

}
