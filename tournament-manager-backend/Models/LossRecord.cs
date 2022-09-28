namespace tournament_manager_backend.Models
{
    public class LossRecord
    {
        public int Id { get; set; }
        public string? Opponent { get; set; }
        public int WinnerScore { get; set; }
        public int LosserScore { get; set; }
        public Player? Player { get; set; }
    }
}
