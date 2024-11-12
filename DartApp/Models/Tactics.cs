using DartApp.Models;

public class Tactics : GameMode
{
    public List<TacticsTarget> TacticsTargets { get; set; }

    public Tactics()
    {
        GameModeId = 3;
        Name = "Tactics";
        TacticsTargets = new List<TacticsTarget>
        {
            new TacticsTarget { Value = 10, HitsRequired = 3 },
            new TacticsTarget { Value = 11, HitsRequired = 3 },
            new TacticsTarget { Value = 12, HitsRequired = 3 },
            new TacticsTarget { Value = 13, HitsRequired = 3 },
            new TacticsTarget { Value = 14, HitsRequired = 3 },
            new TacticsTarget { Value = 15, HitsRequired = 3 },
            new TacticsTarget { Value = 16, HitsRequired = 3 },
            new TacticsTarget { Value = 17, HitsRequired = 3 },
            new TacticsTarget { Value = 18, HitsRequired = 3 },
            new TacticsTarget { Value = 19, HitsRequired = 3 },
            new TacticsTarget { Value = 20, HitsRequired = 3 },
            new TacticsTarget { Value = 25, HitsRequired = 3 }
        };
    }

    public override void StartGame()
    {
        foreach (var player in Players)
        {
            player.Score = 0;
        }
    }

    public override void CalculateScore(int playerId, int targetValue)
    {
        var player = Players.First(p => p.PlayerId == playerId);
        var target = TacticsTargets.FirstOrDefault(t => t.Value == targetValue);
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
