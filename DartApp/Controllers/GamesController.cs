using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DartApp.Data;
using DartApp.Models;

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
            var game = _context.Games
                .Include(g => g.Players)
                .FirstOrDefault(g => g.GameId == gameId);

            if (game == null) return NotFound();

            var model = new Game301ViewModel
            {
                PlayerName = game.Players.First().Name,
                CurrentScore = game.Players.First().Score
            };

            return View(model); // Past bij @model Game301ViewModel
        }


        [HttpPost]
        public IActionResult UpdateScore(int gameId, int playerId, int score)
        {
            var player = _context.Players.FirstOrDefault(p => p.PlayerId == playerId && p.GameId == gameId);
            if (player == null)
            {
                return Json(new { success = false, message = "Speler niet gevonden!" });
            }

            // Controleer of de score geldig is
            if (score > player.Score)
            {
                return Json(new { success = false, message = "Bust! Score is te hoog." });
            }

            // Update de score
            player.Score -= score;

            // Check voor winst
            if (player.Score == 0)
            {
                return Json(new { success = true, newScore = 0, message = "Gewonnen!" });
            }

            _context.SaveChanges();

            return Json(new { success = true, newScore = player.Score });
        }
    }
}
