using BulkyBook.Data;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Controllers
{
    public class CategoryController1 : Controller
    {
        private readonly AppDbContext _db;
        public CategoryController1(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories; // created an object to use the properties of the class.
            return View(objCategoryList);
        }
        // GET method
        public IActionResult Create()
        {
            return View();
        }
        // POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.Displayorder.ToString())
            {
                ModelState.AddModelError("Name", "Display Order and Name cannot be same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges(); // At this point of time the data is posted to database
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index"); // We need to specify the controller name where we want to route it
            }
            return View(obj);

        }

        // GET method
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var dbCategories = _db.Categories.Find(id);
            //var categoriesFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id); this is what First or default is written.
            //var categoriesFromDbSingle = _db.Categories.FirstOrDefault(u => u.Id == id);
            if(dbCategories == null)
            {
                return NotFound();
            }
            return View(dbCategories);
        }
        // POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.Displayorder.ToString())
            {
                ModelState.AddModelError("Name", "Display Order and Name cannot be same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges(); // At this point of time the data is posted to database
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index"); // We need to specify the controller name where we want to route it
            }
            return View(obj);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var dbCategories = _db.Categories.Find(id);
            //var categoriesFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id); this is what First or default is written.
            //var categoriesFromDbSingle = _db.Categories.FirstOrDefault(u => u.Id == id);
            if (dbCategories == null)
            {
                return NotFound();
            }
            return View(dbCategories);
        }
        // POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int? id)
        {
            var obj = _db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
