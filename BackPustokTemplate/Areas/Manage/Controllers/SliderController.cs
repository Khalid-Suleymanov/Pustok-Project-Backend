using BackPustokTemplate.DAL;
using BackPustokTemplate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackPustokTemplate.Areas.Manage.Controllers
{
    [Area("manage")]
    public class SliderController : Controller
    {
        private readonly PustokDbContext _context;

        public SliderController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Sliders.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid)
                return View();

            if (_context.Authors.Any(x => x.Id == slider.Id))
            {
                ModelState.AddModelError("Name", "Name is already taken");
                return View();
            }

            _context.Sliders.Add(slider);

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);

            return View(slider);
        }

        [HttpPost]
        public IActionResult Edit(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
               
            Slider existSlider = _context.Sliders.FirstOrDefault(x => x.Id == slider.Id);

            existSlider.Order = existSlider.Order;
            existSlider.Title1 = existSlider.Title1;
            existSlider.Title2 = existSlider.Title2;
            existSlider.ImageName = existSlider.ImageName;
            existSlider.BtnText = existSlider.BtnText;
            existSlider.BtnUrl = existSlider.BtnUrl;
            existSlider.Desc = existSlider.Desc;

            _context.SaveChanges();

            return RedirectToAction("index");
        }
        
        public IActionResult Delete(int id)
        {
            _context.Sliders.Remove(_context.Sliders.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}