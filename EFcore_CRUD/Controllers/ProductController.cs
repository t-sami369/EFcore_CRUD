using EFcore_CRUD.Models;
using EFcore_CRUD.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ProductApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _repo;

        public ProductController(IRepository<Product> repo)
        {
            _repo = repo;
        }

        // GET: ProductController
        public IActionResult Index()
        {
            var products = _repo.GetAllRecords().ToList();
            return View(products);
        }

        // GET: ProductController/Details/5
        public IActionResult Details(int id)
        {
            var product = _repo.GetSingleRecord(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.AddRecord(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        // GET: ProductController/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _repo.GetSingleRecord(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            try
            {
                if (id != product.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _repo.UpdateRecord(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        // GET: ProductController/Delete/5
        public IActionResult Delete(int id)
        {
            var product = _repo.GetSingleRecord(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _repo.GetSingleRecord(id);
            if (product == null)
            {
                return NotFound();
            }

            _repo.DeleteRecord(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
