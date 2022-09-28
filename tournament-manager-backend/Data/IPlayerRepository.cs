using Microsoft.AspNetCore.Mvc;
using tournament_manager_backend.Models;

namespace tournament_manager_backend.Data
{
    public interface IPlayerRepository
    {

        Player Add(Player player);
        Player GetById(int id);
        IEnumerable<Player> GetAll();

        void Delete(int id);

        void UpdateRating(int id, int newRating);

        void UpdatePlayer(int id, String newName, int newPower);
    }
}
