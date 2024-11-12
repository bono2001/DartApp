namespace DartApp.Models
{
    public class GameMode501 : GameMode
    {
        public GameMode501()
        {
            GameModeId = 2;
            Name = "501";
        }

        public override void StartGame()
        {
            foreach (Player player in Players)
            {
                player.Score = 501;
            }
        }

        public override void CalculateScore(int playerId, int score)
        {
            var player = Players.First(p => p.PlayerId == playerId);
            player.Score -= score;
            if (player.Score < 0)
            {
                player.Score += score;
            }
        }

        public override bool CheckWinCondition()
        {
            return Players.Any(p => p.Score == 0);
        }

        public override void SwitchTurn()
        {
            var index = Players.IndexOf(CurrentTurn);
            if (index == Players.Count - 1)
            {
                CurrentTurn = Players.First();
            }
            else
            {
                CurrentTurn = Players[index + 1];
            }
        }
    }
}
