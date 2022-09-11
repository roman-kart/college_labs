using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FoodStoreApp.Data;
using FoodStoreApp.Models;
using FoodStoreApp.Models.ViewModels;

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
            ViewBag._db = _db;
            return View(_db.Products.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel pvm)
        {
            //Console.WriteLine($"ModelState.IsValid: {ModelState.IsValid}");
            //Helpers.ClassHelpers.ShowFieldsValues<ProductViewModel>(pvm);
            if (ModelState.IsValid)
            {
                var product = pvm.ToProduct();
                _db.Products.Add(product);
                if (pvm.Images != null)
                {
                    foreach (var img in pvm.Images)
                    {
                        byte[] imageData = null;
                        // считываем переданный файл в массив байтов
                        using (var binaryReader = new BinaryReader(img.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)img.Length);
                        }
                        // установка массива байтов
                        var userFile = new UserFile()
                        {
                            Content = imageData,
                            Title = img.FileName,
                            Type = img.ContentType,
                            Product = product
                        };
                        _db.UserFiles.Add(userFile);
                    }
                }
                _db.SaveChanges();
            }
            return RedirectToAction("Upsert");
        }
        public IActionResult Upsert(int? id)
        {
            var categoriesSelectItems = _db.Category.Select(
                item => 
                    new SelectListItem()
                    {
                        Value = item.CategoryId.ToString(),
                        Text = item.Title
                    }
            );
            ViewBag.CategoryDropDown = categoriesSelectItems;

            var manufacturersSelectItem = _db.Manufacturers.Select(
                item =>
                    new SelectListItem()
                    {
                        Value = item.ManufacturerId.ToString(),
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
                product = _db.Products.FirstOrDefault(x => x.ProductId == id);
                if (product == null)
                {
                    return NotFound();
                }
            }
            return View(ProductViewModel.FromProduct(product));
        }
    }
}
