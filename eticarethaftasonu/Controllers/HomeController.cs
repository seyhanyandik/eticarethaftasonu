using eticarethaftasonu.Data;
using eticarethaftasonu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace eticarethaftasonu.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Urunler()
        {
            List<Category>kategoriler=_context.Categories.ToList();
            ViewBag.categoriler = kategoriler;
            var liste=_context.Products.Include(p=>p.Category).ToList();
            return View(liste);
        }
        [HttpGet]
        public IActionResult Detay(int? id)
        {
            var bul = _context.Products.Include(p => p.Category).FirstOrDefault();
            return View(bul);
        }
        [HttpGet]
        public IActionResult Kategoriler(int? id)
        {
            List<Category> kategoriler = _context.Categories.ToList();
            ViewBag.categoriler = kategoriler;
            var secim=_context.Products.Include(p=>p.Category).Where(x=>x.CategoryId == id).ToList();
            return View(secim);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult PageNot()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}