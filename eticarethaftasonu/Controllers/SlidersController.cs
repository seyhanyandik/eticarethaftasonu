﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eticarethaftasonu.Data;
using eticarethaftasonu.Models;

namespace eticarethaftasonu.Controllers
{
    public class SlidersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlidersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sliders
        public async Task<IActionResult> Index()
        {
              return _context.Sliders != null ? 
                          View(await _context.Sliders.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Sliders'  is null.");
        }

        // GET: Sliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sliders == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders
                .FirstOrDefaultAsync(m => m.SliderId == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // GET: Sliders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SliderId,Header1,Header2,Context,SliderImage")] Slider slider,IFormFile ResimYukle)
        {
            if (ResimYukle != null)
            {
                var uzanti = Path.GetExtension(ResimYukle.FileName);
                //bocek.png  .png domates.jpg  .jpg
                string yeniisim = Guid.NewGuid().ToString() + uzanti;

                string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Slider/" + yeniisim);
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    ResimYukle.CopyToAsync(stream);
                }
                slider.SliderImage = yeniisim;
            }


            if (ModelState.IsValid)
            {
                _context.Add(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        // GET: Sliders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sliders == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SliderId,Header1,Header2,Context,SliderImage")] Slider slider)
        {
            if (id != slider.SliderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SliderExists(slider.SliderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        // GET: Sliders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sliders == null)
            {
                return NotFound();
            }

            var slider = await _context.Sliders
                .FirstOrDefaultAsync(m => m.SliderId == id);
            if (slider == null)
            {
                return NotFound();
            }

            return View(slider);
        }

        // POST: Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sliders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sliders'  is null.");
            }
            var slider = await _context.Sliders.FindAsync(id);
            if (slider != null)
            {
                _context.Sliders.Remove(slider);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SliderExists(int id)
        {
          return (_context.Sliders?.Any(e => e.SliderId == id)).GetValueOrDefault();
        }
    }
}
