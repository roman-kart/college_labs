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
        public IActionResult Create(Manufacturer manuf)
        {
            if (ModelState.IsValid)
            {
                _db.Manufacturers.Add(manuf);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manuf);

        }


        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var manuf = _db.Manufacturers.Find(id);
            if (manuf == null)
            {
                return NotFound();
            }

            return View(manuf);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Manufacturer manuf)
        {
            Console.WriteLine($"Is model valid: {ModelState.IsValid}");
            if (ModelState.IsValid)
            {
                _db.Manufacturers.Update(manuf);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manuf);

        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var manuf = _db.Manufacturers.Find(id);
            if (manuf == null)
            {
                return NotFound();
            }

            return View(manuf);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var manuf = _db.Manufacturers.Find(id);
            if (manuf == null)
            {
                return NotFound();
            }
            _db.Manufacturers.Remove(manuf);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
