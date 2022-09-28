using tournament_manager_backend.Models;

namespace tournament_manager_backend.Data
{
    public interface IMatchRepository
    {
        void AddMatchResult(WinRecord winner, LossRecord loser);
    }
}
