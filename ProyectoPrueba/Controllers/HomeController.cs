using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoPrueba.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ProyectoPrueba.DTBConnection;

namespace ProyectoPrueba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CRUD crud;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            crud = new CRUD();

        }

        public IActionResult Tareas()
        {

            return View(crud.Get());
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(string nombre)
        {

            crud.Insert(nombre);
            return RedirectToAction("Tareas");
        }

        public IActionResult Completado(int id)
        {
            crud.Update(id);
            return RedirectToAction("Tareas");

        }

        public IActionResult Borrar(int id)
        {
            crud.Borrar(id);
            return RedirectToAction("Tareas");

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
