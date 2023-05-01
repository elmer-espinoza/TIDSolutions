using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TIDSolutions.Models;

namespace TIDSolutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly AutoContext _dbContext;
        public HomeController(AutoContext dbcontext) { _dbContext = dbcontext; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            return View(_dbContext.Autos.OrderBy(e => e.Propietario));
        }

        public IActionResult Crear()
        {
            return View(new Auto() { Disponible=true });
        }

        [HttpPost]
        public IActionResult Crear(Auto auto)
        {
            _dbContext.Autos.Add(auto);
            _dbContext.SaveChanges();
            return RedirectToAction("Listar");
        }
        public IActionResult Eliminar(string id)
        {
            return View(_dbContext.Autos.FirstOrDefault(e => e.Placa == id));
        }

        [HttpPost]
        public IActionResult Eliminar(Auto auto)
        {
            _dbContext.Autos.Remove(auto);
            _dbContext.SaveChanges();
            return RedirectToAction("Listar");
        }

        public IActionResult Editar(string id)
        {
            return View(_dbContext.Autos.FirstOrDefault(e => e.Placa == id));
        }

        [HttpPost]
        public IActionResult Editar(Auto auto)
        {
            _dbContext.Autos.Update(auto);
            _dbContext.SaveChanges();
            return RedirectToAction("Listar");
        }

        public IActionResult Detalles(string id)
        {
            return View(_dbContext.Autos.FirstOrDefault(e => e.Placa == id));
        }

        public IActionResult Privacy()
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