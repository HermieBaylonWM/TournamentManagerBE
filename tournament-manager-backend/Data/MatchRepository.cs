using Microsoft.AspNetCore.Mvc;
using System.Linq;
using tournament_manager_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace tournament_manager_backend.Data
{
    public class MatchRepository : IMatchRepository
    {
        private readonly ApplicationDbContext _context;

        public MatchRepository(ApplicationDbContext context)
        { 
            _context = context;
        }

        public void AddMatchResult(WinRecord winner, LossRecord loser)
        {
            _context.WinRecords.Add(winner);
            _context.LossRecords.Add(loser);
            _context.SaveChanges();
        }
    }
}
