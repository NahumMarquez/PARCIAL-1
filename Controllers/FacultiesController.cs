using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using parcial1.Data;
using parcial1.Models;

namespace parcial1.Controllers
{
    public class FacultiesController : Controller
    {
        private readonly AppDbContext _context;

        public FacultiesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var faculties = await _context.Faculties.ToListAsync();
            if (!faculties.Any())
            {
                ViewBag.Message = "No hay facultades registradas.";
            }
            return View(faculties);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            if (id == null)
            {
                return View(new Faculties());
            }

            var faculty = await _context.Faculties.FindAsync(id);
            return faculty == null ? NotFound() : View(faculty);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Faculties faculty)
        {
            if (!ModelState.IsValid) return View(faculty);

            if (faculty.FacultiesId == 0)
            {
                faculty.Created = DateTime.Now;
                _context.Faculties.Add(faculty);
            }
            else
            {
                faculty.Edited = DateTime.Now;
                _context.Faculties.Update(faculty);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var faculty = await _context.Faculties.FindAsync(id);
            if (faculty == null) return NotFound();

            _context.Faculties.Remove(faculty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
