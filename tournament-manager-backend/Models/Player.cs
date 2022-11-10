using System.Collections;

namespace tournament_manager_backend.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; } // Skill Level (1, 2, 3, 4, etc)
        public int Rating { get; set; }
        public ICollection<WinRecord> Wins { get; set; }
        public ICollection<LossRecord> Losses { get; set; }

        public Player()
        {
            Rating = 1000;
        }
    }
}
