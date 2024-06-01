using Ecommerce.Data;
using Ecommerce.Models;

using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers

{
	public class CategoryController : Controller
	{
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public IActionResult Index() {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid) {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created";
                return RedirectToAction("Index");
            }
            return View(); 

        }

        public IActionResult Edit(int categoryId)
        {   
            if (categoryId == null || categoryId == 0) {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(categoryId);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Edited";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(categoryId);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? categoryId)
        {
            Category obj = _db.Categories.Find(categoryId);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();

            TempData["success"] = "Category Deleted";
            return RedirectToAction("Index");

        }
    }
}
