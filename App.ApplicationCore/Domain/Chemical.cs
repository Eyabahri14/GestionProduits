using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Chemical : Product
    {
        public string LabName { get; set; }
        //public string City { get; set; }
        //public string StreetAddress { get; set; }
        public Address Address { get; set; }

        public override void GetMyType()
        {
            base.GetMyType();
            Console.WriteLine("chimique");
        }
    }
}
