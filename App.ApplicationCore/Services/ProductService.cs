using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IFactureService _factureService;
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
        public void DeleteOldProducts()
        {
            // Delete(p => (DateTime.Now - p.DateProd).TotalDays > 365);
            //Ca c'est plus une date mais un nouveau type qui s'apelle Time spam qui est un interval : (DateTime.Now - p.DateProd)
        }

        public IEnumerable<Product> FindMost5ExpensiveProds()
        {
            return GetAll().OrderByDescending(p => p.Price).Take(5);
        }

        public IEnumerable<Product> GetProdsByClient(Client c)
        {

            return _factureService.GetMany(f => f.Client == c).ToList()
                 .Select(f => f.Product);



        }

        public float UnavailableProductsPercentage()
        {
            float result = GetMany(p => p.Quantity == 0).Count();

            float resultAll = GetAll().Count();

            return result / resultAll;
        }

    }
}
