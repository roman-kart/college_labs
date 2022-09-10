using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FoodStoreApp.Data;
using FoodStoreApp.Models;

namespace FoodStoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext _db)
        {
            this._db = _db;
        }
        public IActionResult Index()
        {
            return View(_db.Products.ToList());
        }
        public IActionResult Upsert(int? id)
        {
            var categoriesSelectItems = _db.Category.Select(
                item => 
                    new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.Title
                    }
            );
            ViewBag.CategoryDropDown = categoriesSelectItems;

            var manufacturersSelectItem = _db.Manufacturers.Select(
                item =>
                    new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.Title
                    }
            );
            ViewBag.ManufacturersDropDown = manufacturersSelectItem;

            Product product;
            if (id == null || id == 0)
            {
                product = new Product();
            }
            else
            {
                product = _db.Products.FirstOrDefault(x => x.Id == id);
                if (product == null)
                {
                    return NotFound();
                }
            }
            return View(product);
        }
    }
}
