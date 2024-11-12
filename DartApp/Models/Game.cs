namespace DartApp.Models
{
    public class Game
    {
        public int GameId { get; set; } // Primaire sleutel
        public int GameModeId { get; set; } // Foreign key
        public GameMode GameMode { get; set; } // Navigatie-eigenschap

        public ICollection<Player> Players { get; set; } // Navigatie naar spelers

        public Game()
        {
            Players = new List<Player>();
        }

        public void StartGame()
        {
            GameMode.StartGame();
        }

        public void AddThrow(int playerId, int score)
        {
           GameMode.CalculateScore(playerId, score);
        }

        public bool CheckWinCondition()
        {
            return GameMode.CheckWinCondition();
        }
    }
}
