using Microsoft.AspNetCore.Mvc;
using proyectog.Data;
using proyectog.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace proyectog.Controllers
{
    public class IngresosController : Controller
    {
        private readonly AppDbContext _context;

        public IngresosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Ingresos.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ingreso ingreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingreso);
        }
    }
}