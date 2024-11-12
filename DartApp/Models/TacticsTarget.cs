namespace DartApp.Models
{
    public class TacticsTarget
    {
        public int TacticsTargetId { get; set; } // Primaire sleutel
        public int Value { get; set; }
        public int HitsRequired { get; set; }
        public int HitsMade { get; set; }

        // Foreign key naar Tactics
        public int TacticsId { get; set; }
        public Tactics Tactics { get; set; } // Navigatie-eigenschap


        public bool IsCompleted()
        {
            return HitsMade >= HitsRequired;
        }
    }
}
