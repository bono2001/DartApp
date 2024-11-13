using DartApp.Models;
using DartApp.Data; // Zorg ervoor dat je namespace correct is
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
            // Haal een lijst van games op
            var games = _context.Games.Include(g => g.GameMode).ToList();
            return View(games); // Dit moet overeenkomen met de view
        }
    }

}