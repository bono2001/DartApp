using System.Media;

namespace DartApp.Models
{
    public abstract class GameMode
    {
        public int GameModeId { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }


        // Relatie naar de speler die aan de beurt is
        public int? CurrentTurnId { get; set; } // Foreign key
        public Player CurrentTurn { get; set; } // Navigatie-eigenschap
        public bool IsFinished { get; set; }



        public abstract void StartGame();
        public abstract void CalculateScore(int playerId, int score);
        public abstract bool CheckWinCondition();
        public abstract void SwitchTurn();
    }
}
