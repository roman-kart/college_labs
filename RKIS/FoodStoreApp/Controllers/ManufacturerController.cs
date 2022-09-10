using Microsoft.AspNetCore.Mvc;
using FoodStoreApp.Data;
using FoodStoreApp.Models;

namespace FoodStoreApp.Controllers
{
    public class ManufacturerController : Controller
    {
        // Переменная контекста для доступа к базе данных
        private readonly ApplicationDbContext _db;
        // Внедряем зависимость ApplicationDbContext через конструктор
        public ManufacturerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // Создаем список записей категорий из базы данных
            IEnumerable<Manufacturer>manufacturerList = _db.Manufacturers;
            // Возвращаем загруженный список в представление
            return View(manufacturerList);
        }
        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }


        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manufacturer cat)
        {

            _db.Manufacturers.Add(cat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            return View();
        }
        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            return View();
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var cat = _db.Manufacturers.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            _db.Manufacturers.Remove(cat);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
