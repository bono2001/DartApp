namespace DartApp.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public GameMode GameMode { get; set; }
        public List<Player> Players { get; set; }


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
