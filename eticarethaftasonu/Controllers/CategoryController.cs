using eticarethaftasonu.Data;
using eticarethaftasonu.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eticarethaftasonu.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        //veritabanı bağlantımı gösteriyor
        public IActionResult Index()
        {
            var categoryList = _context.Categories.ToList();
            return View(categoryList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category gelen)
        {
            _context.Add(gelen);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]   
        public IActionResult Edit(int id)
        {
            //var getir = _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            var getir = _context.Categories.Find(id);
            return View(getir);
        }
        [HttpPost]
        public IActionResult Edit(Category gelen)
        {
            _context.Update(gelen);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var getir = _context.Categories.Find(id);
            return View(getir);
        }
        [HttpPost]
        public IActionResult Delete(Category gelen)
        {
            _context.Remove(gelen);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
