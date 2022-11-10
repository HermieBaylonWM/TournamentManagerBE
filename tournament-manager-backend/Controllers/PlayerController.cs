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
        private readonly IPlayerRepository _playerRepository;
        private readonly IRecordRepository _recordRepository;

        public PlayerController(IPlayerRepository playerRepository, IRecordRepository recordRepository)
        {
            _playerRepository = playerRepository;
            _recordRepository = recordRepository;
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
            _playerRepository.Add(player);
        }

        [HttpGet("GetPlayerById/{id}")]
        public Player GetPlayerById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("id must be a positive number");
            }
            var player = _playerRepository.GetById(id);
            if (player == null)
            {
                throw new NullReferenceException("Player with id: "+id+" does not exist");
            }
            return player;
        }

        [HttpGet("GetAllPlayers")]
        public IEnumerable<Player> GetAllPlayers()
        {
            return _playerRepository.GetAll();
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
                throw new ArgumentException("id must be a positive number");
            }
            _playerRepository.Delete(id);
        }

        [HttpPut("UpdatePlayerRating/{id}")]
        public void UpdatePlayerRating(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("id must be a positive number");
            }
            _playerRepository.UpdateRating(id, 2000);//testing
        }

        [HttpPut("UpdatePlayer/{id}/{newName}/{newPower}")]
        public void UpdatePlayer(int id, String newName, int newPower) 
        {
            if (id < 0)
            {
                throw new ArgumentException("id must be a positive number");
            }
            _playerRepository.UpdatePlayer(id, newName, newPower);
        }
    }
}
