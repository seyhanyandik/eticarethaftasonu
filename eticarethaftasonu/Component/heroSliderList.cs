using eticarethaftasonu.Data;
using eticarethaftasonu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eticarethaftasonu.Component
{
    public class heroSliderList: ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public heroSliderList(ApplicationDbContext context)
        {
             _context= context;
        }
        public  IViewComponentResult Invoke()
        {
            var liste = _context.Sliders.OrderByDescending(s => s.SliderId).FirstOrDefault();
            return View(liste);
		}
    }
}
