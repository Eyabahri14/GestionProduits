using App.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Interfaces
{
    public interface IProductService : IService<Product>
    {
        public IEnumerable<Product> FindMost5ExpensiveProds();
        public float UnavailableProductsPercentage();

        public IEnumerable<Product> GetProdsByClient(Client c);
        public void DeleteOldProducts();
    }
}
