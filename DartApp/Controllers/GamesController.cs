using DartApp.Data;
using DartApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DartApp.Controllers
{
    public class GamesController : Controller
    {
        private readonly DartAppContext _context;

        public GamesController(DartAppContext context)
        {
            _context = context;
        }

        public IActionResult Index(int gameId)
        {
            // Haal de game op uit de database
            var game = _context.Games
                .Include(g => g.Players)
                .Include(g => g.GameMode)
                .FirstOrDefault(g => g.GameId == gameId);

            if (game == null) return NotFound();

            // Maak een viewmodel aan voor de 301-game
            var model = new Game301ViewModel
            {
                PlayerName = game.Players.FirstOrDefault()?.Name ?? "Speler 1",
                CurrentScore = 301 // Beginscore
            };

            return View("Index", model); // Views/Games/Index.cshtml
        }
    }
}
