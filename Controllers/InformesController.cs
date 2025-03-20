using Microsoft.AspNetCore.Mvc;
using proyectog.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace proyectog.Controllers
{
    public class InformesController : Controller
    {
        private readonly AppDbContext _context;

        public InformesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var gastos = await _context.Gastos.ToListAsync();
            var ingresos = await _context.Ingresos.ToListAsync();

            decimal totalGastos = gastos.Sum(g => g.Monto);
            decimal totalIngresos = ingresos.Sum(i => i.Monto);
            decimal balance = totalIngresos - totalGastos;

            ViewBag.TotalGastos = totalGastos;
            ViewBag.TotalIngresos = totalIngresos;
            ViewBag.Balance = balance;

            return View();
        }
    }
}