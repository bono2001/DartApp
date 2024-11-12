namespace DartApp.Models
{
    public class Tactics : GameMode
    {
        public Tactics()
        {
            GameModeId = 3;
            Name = "Tactics";
        }

        public override void StartGame()
        {
            foreach (Player player in Players)
            {
                player.Score = 0;
            }
        }

        public override void CalculateScore(int playerId, int score)
        {
            var player = Players.First(p => p.PlayerId == playerId);
            var target = TacticsTargets.FirstOrDefault(t => t.Target == score);
            if (target != null && !target.IsCompleted())
            {
                target.HitsMade++;
            }
        }

        public override bool CheckWinCondition()
        {
            return TacticsTargets.All(t => t.IsCompleted());
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
