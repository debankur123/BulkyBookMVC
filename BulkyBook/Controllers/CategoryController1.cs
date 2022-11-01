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
        public IActionResult Create()
        {
            return View();
        }
    }
}
