using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using SSMAGA_ZALICZENIE.Contexts;
using SSMAGA_ZALICZENIE.Logic;
using SSMAGA_ZALICZENIE.Models;
using System.Diagnostics;

namespace SSMAGA_ZALICZENIE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        { 
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var itemManager = new CzarterManager();
            var item = itemManager.getItem(id);
            return View(item);
        }

        [HttpGet]
        public IActionResult Oferta()
        {
            var manager = new CzarterManager();
            var items = manager.PobierzJednostki();
            return View(items);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(OfertaModel item)
        {
            var itemManager = new CzarterManager();
            itemManager.addItem(item);
            return RedirectToAction("Oferta");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var itemManager = new CzarterManager();
            var item = itemManager.getItem(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(OfertaModel ofertaModel)
        {
            var itemManager = new CzarterManager();
            itemManager.updateItem(ofertaModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var itemManager = new CzarterManager();
            var item = itemManager.getItem(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            var itemManager = new CzarterManager();

            try
            {
                var car = itemManager.getItem(id);
                itemManager.removeItem(car.ID);
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public IActionResult ONas()
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