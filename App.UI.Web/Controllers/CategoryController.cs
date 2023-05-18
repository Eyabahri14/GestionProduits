using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace App.UI.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController

        IUnitOfWork unitOfWork;
        ICategoryService categoryService;
      
        public CategoryController(IUnitOfWork unitOfWork,ICategoryService categoryService)
        {
            this.unitOfWork = unitOfWork;
            this.categoryService = categoryService;

        }
        public ActionResult Index()
        {
            return View(categoryService.GetAll());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                categoryService.Add(category);
                unitOfWork.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
