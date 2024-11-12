using System.Media;

namespace DartApp.Models
{
    public abstract class GameMode
    {
        public int GameModeId { get; set; }
        public string Name { get; set; }
        public List<Player> Players
        public Player CurrentTurn { get; set; }
        public bool IsFinished { get; set; }



        public abstract void StartGame();
        public abstract void CalculateScore(int playerId, int score);
        public abstract bool CheckWinCondition();
        public abstract void SwitchTurn();
    }
}
