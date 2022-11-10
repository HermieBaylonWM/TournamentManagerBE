using tournament_manager_backend.Models;

namespace tournament_manager_backend.Data
{
    public interface IRecordRepository
    {
        WinRecord AddWinRecord(WinRecord winRecord);

        LossRecord AddLossRecord(LossRecord lossRecord);

        IEnumerable<WinRecord> GetAllWins(int playerId);

        IEnumerable<LossRecord> GetAllLosses(int playerId);
    }
}
