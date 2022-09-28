using Microsoft.AspNetCore.Mvc;
using System.Linq;
using tournament_manager_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace tournament_manager_backend.Data
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;
        public PlayerRepository(ApplicationDbContext context)
        { 
            _context = context;
        }

        public Player Add(Player player)
        {
            _context.Players.Add(player);
            //player.Id = await _context.SaveChangesAsync();
            _context.SaveChanges();
            return player;
        }

        public Player GetById(int id)
        {
            return _context.Players.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Player> GetAll()
        {
            var players = _context.Players.OrderByDescending(p => p.Rating);
            return players;
        }

        public void Delete(int id)
        {
            var player = _context.Players.Find(id);
            if (player == null)
            {
                throw new Exception("No Player found with id: " +id);
            }
            _context.Players.Remove(player);
            _context.SaveChanges();
        }

        public void UpdateRating(int id, int newRating)
        {
            var player = _context.Players.Find(id);
            if (player == null)
            {
                throw new Exception("No player found with id: "+id);
            }
            player.Rating = newRating;
            _context.Players.Update(player);
            _context.SaveChanges();
        }

        public void UpdatePlayer(int id, String newName, int newPower)
        {
            var player = _context.Players.Find(id);
            if (player == null)
            {
                throw new Exception("No player found with id: " + id);
            }
            player.Name = newName;
            player.Power = newPower;
            _context.Players.Update(player);
            _context.SaveChanges();
        }
    }
}
