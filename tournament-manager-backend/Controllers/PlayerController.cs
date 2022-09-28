using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tournament_manager_backend.Data;
using tournament_manager_backend.Dtos;
using tournament_manager_backend.Models;

namespace tournament_manager_backend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _repository;

        public PlayerController(IPlayerRepository repository)
        { 
            _repository = repository;
        }

        // api/addplayer
        [HttpPost("addplayer")]
        public void AddPlayer(PlayerDto dto)
        {
            var player = new Player
            {
                Name = dto.Name,
                Power = dto.Power
            };
            _repository.Add(player);
        }

        [HttpGet("GetPlayerById/{id}")]
        public Player GetPlayerById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("id must be a positive number");
            }
            var player = _repository.GetById(id);
            if (player == null)
            {
                throw new NullReferenceException("Player with id: "+id+" does not exist");
            }
            return player;
        }

        [HttpGet("GetAllPlayers")]
        public IEnumerable<Player> GetAllPlayers()
        {
            return _repository.GetAll();
        }

        [HttpGet("GetMock")]
        public String GetMock()
        {
            return "Mock Data";
        }

        [HttpDelete("DeletePlayer/{id}")]
        public void DeletePlayer(int id)
        {
            if (id < 0)
            {
                //throw new ArgumentOutOfRangeException("id must be a positive number");
                throw new ArgumentException("id must be a positive number");
            }
            _repository.Delete(id);
        }

        [HttpPut("UpdatePlayerRating/{id}")]
        public void UpdatePlayerRating(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("id must be a positive number");
            }
            _repository.UpdateRating(id, 2000);
        }

        [HttpPut("UpdatePlayer/{id}/{newName}/{newPower}")]
        public void UpdatePlayer(int id, String newName, int newPower) 
        {
            if (id < 0)
            {
                throw new ArgumentException("id must be a positive number");
            }
            _repository.UpdatePlayer(id, newName, newPower);
        }
    }
}
