namespace DartApp.Models
{
    public class TacticsTarget
    {
        public int Value { get; set; }
        public int HitsRequired { get; set; }
        public int HitsMade { get; set; }


        public bool IsCompleted()
        {
            return HitsMade >= HitsRequired;
        }
    }
}
