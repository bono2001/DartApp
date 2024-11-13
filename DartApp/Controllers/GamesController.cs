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

        public async Task<IActionResult> Index()
        {
            var dartAppContext = _context.Games.Include(g => g.GameMode);
            return View(await dartAppContext.ToListAsync());
        }

        public IActionResult Play301(int gameId)
        {
            var game = _context.Games
                .Include(g => g.Players)
                .FirstOrDefault(g => g.GameId == gameId);

            if (game == null)
                return NotFound();

            var model = new Game301ViewModel
            {
                PlayerName = game.Players.First().Name,
                CurrentScore = game.Players.First().Score
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateScore(int gameId, int playerId, int score)
        {
            var game = _context.Games
                .Include(g => g.Players)
                .FirstOrDefault(g => g.GameId == gameId);

            if (game == null)
                return Json(new { success = false, message = "Game niet gevonden." });

            var player = game.Players.FirstOrDefault(p => p.PlayerId == playerId);

            if (player == null)
                return Json(new { success = false, message = "Speler niet gevonden." });

            if (score > player.Score)
                return Json(new { success = false, message = "Bust! Probeer opnieuw." });

            player.Score -= score;

            if (player.Score == 0)
                return Json(new { success = true, newScore = 0, message = $"{player.Name} heeft gewonnen!" });

            _context.SaveChanges();

            return Json(new { success = true, newScore = player.Score });
        }
    }
}
