using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using App.ApplicationCore.Services;
using App.UI.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;

namespace App.UI.Web.Controllers
{
    public class ProductController : Controller
    {
        IUnitOfWork unitOfWork;
        IProductService productService;
        ICategoryService categoryService;
        IWebHostEnvironment webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork,IProductService productService, IWebHostEnvironment webHostEnvironment,ICategoryService categoryService)
        {
            this.unitOfWork = unitOfWork;
            this.productService = productService;
            this.categoryService=categoryService;   
            this.webHostEnvironment = webHostEnvironment;

        }
        // GET: ProductController
        [HttpGet]
        public ActionResult Index()
        {
            return View(productService.GetAll());
        }

        [HttpPost]
        public ActionResult Index(string name)
        {
            var products = productService.GetAll();

            if (!string.IsNullOrEmpty(name))
            {
                products = products.Where(p => p.Name.Contains(name));
            }

            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(productService.GetById(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(categoryService.GetAll().Select(e => new { e.CategoryId, Description = $"CategoryId : {e.CategoryId}, Name = {e.Name}" }), nameof(Category.CategoryId), "Description");
            return View();
        }

       

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var fileName = Request.AddRequestFile(webHostEnvironment, "wwwroot", "upload");

                p.Image = fileName;
                productService.Add(p);
                unitOfWork.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(productService.GetById(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product updateProduct)
        {
            try
            {
                productService.Update(updateProduct);
                unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(productService.GetById(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product p)
        {
            try
            {
                p.ProductId = id;
                productService.Delete(p);
                unitOfWork.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }
    }
}
