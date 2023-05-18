using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{

    public class Client
    {

        [Key]
        public string Cin { get; set; }
        public string Email { get; set; }
        public string Nom { get; set; }
        public virtual List<Facture> Factures { get; set; }
        public string Prenom { get; set; }

    }
}
