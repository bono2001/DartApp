using DartApp.Data;
using DartApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DartAppContext _context; // Voeg dit veld toe

        // Constructor met dependency injection
        public HomeController(ILogger<HomeController> logger, DartAppContext context)
        {
            _logger = logger;
            _context = context; // Initialiseer de context
        }

        public IActionResult Index()
        {
            // Haal games op uit de database
            var games = _context.Games.Include(g => g.GameMode).ToList();
            return View(games); // Controleer dat dit klopt met je view's @model
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
