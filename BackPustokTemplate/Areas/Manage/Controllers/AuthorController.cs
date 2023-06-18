using BackPustokTemplate.DAL;
using BackPustokTemplate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackPustokTemplate.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AuthorController : Controller
    {
        private readonly PustokDbContext _context;

        public AuthorController(PustokDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Authors.Include(x=>x.Books).ToList());
        }

        

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (!ModelState.IsValid)
                return View();

            if (_context.Authors.Any(x => x.FullName == author.FullName))
            {
                ModelState.AddModelError("Name", "Name is already taken");
                return View();
            }

            _context.Authors.Add(author);

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Author author = _context.Authors.FirstOrDefault(x => x.Id == id);

            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (!ModelState.IsValid)
                return View();

            Author existAuthor = _context.Authors.FirstOrDefault(x => x.Id == author.Id);

            existAuthor.FullName = author.FullName;

            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            _context.Authors.Remove(_context.Authors.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
