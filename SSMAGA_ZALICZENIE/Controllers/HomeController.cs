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
        private readonly CzarterContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeController(IWebHostEnvironment env, CzarterContext context, ILogger<HomeController> logger)
        {
            _env = env;
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var manager = new CzarterManager();
            var jachty = manager.PobierzJednostki();
            return View(jachty);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
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