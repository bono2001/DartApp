namespace DartApp.Models
{
    public class Player
    {
        public int PlayerId { get; set; } // Primaire sleutel
        public string Name { get; set; }
        public int Score { get; set; }

        // Relatie naar Game
        public int GameId { get; set; } // Foreign key
        public Game Game { get; set; } // Navigatie-eigenschap
    }
}
