using System.Numerics;
using tournament_manager_backend.Models;

namespace tournament_manager_backend.Data
{
    public class RecordRepository : IRecordRepository
    {
        private readonly ApplicationDbContext _context;

        public RecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public WinRecord AddWinRecord(WinRecord winRecord)
        {
            _context.WinRecords.Add(winRecord);
            _context.SaveChanges();
            return winRecord;
        }

        public LossRecord AddLossRecord(LossRecord lossRecord)
        {
            _context.LossRecords.Add(lossRecord);
            _context.SaveChanges();
            return lossRecord;
        }

        public IEnumerable<WinRecord> GetAllWins(int playerId)
        {
            var wins = _context.WinRecords.Where(w => w.Player.Id == playerId);
            return wins;
        }

        public IEnumerable<LossRecord> GetAllLosses(int playerId)
        {
            var losses = _context.LossRecords.Where(l => l.Player.Id == playerId);
            return losses;
        }
    }
}
