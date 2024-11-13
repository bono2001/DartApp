using DartApp.Data;
using DartApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly DartAppContext _context;

        public HomeController(DartAppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Haal een lijst van games op uit de database
            var games = _context.Games.Include(g => g.GameMode).ToList();

            // Controleer of er games in de database staan
            if (games == null || !games.Any())
            {
                ViewBag.Message = "Er zijn geen games beschikbaar.";
                return View(new List<Game>());
            }

            return View(games); // Zorg dat dit overeenkomt met je view
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
