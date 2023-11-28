using eticarethaftasonu.Data;
using eticarethaftasonu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eticarethaftasonu.Component
{
    public class SliderList:ViewComponent
    {
         ApplicationDbContext _context;

        public SliderList(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<Slider> sliderlist = _context.Sliders.ToList();
            return View(sliderlist);
        }
    }
}
