using Microsoft.AspNetCore.Mvc;
using System.Linq;
using tournament_manager_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace tournament_manager_backend.Data
{
    public class MatchRepository : IMatchRepository
    {
        private readonly IRecordRepository _recordRepository;

        public MatchRepository(IRecordRepository recordRepository)
        { 
            _recordRepository = recordRepository;
        }

        public void AddMatchResult(WinRecord winner, LossRecord loser)
        {
            _recordRepository.AddWinRecord(winner);
            _recordRepository.AddLossRecord(loser);
        }
    }
}
