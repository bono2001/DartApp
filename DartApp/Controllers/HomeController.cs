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

            // Geef deze lijst door aan de view
            return View(games); // Past bij Views/Home/Index.cshtml
        }

        public IActionResult Privacy()
        {
            return View(); // Views/Home/Privacy.cshtml
        }
    }
}
