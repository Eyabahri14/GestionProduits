using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {

        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }


    }
}
