using Microsoft.AspNetCore.Mvc;
using tournament_manager_backend.Data;
using tournament_manager_backend.Models;

namespace tournament_manager_backend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordRepository _recordRepository;
        public RecordController(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        [HttpGet("GetAllWinRecords/{playerId}")]
        public IEnumerable<WinRecord> GetAllWinRecords(int playerId)
        {
            return _recordRepository.GetAllWins(playerId);
        }

        [HttpGet("GetAllLosses/{playerId}")]
        public IEnumerable<LossRecord> GetAllLossRecords(int playerId)
        {
            return _recordRepository.GetAllLosses(playerId);
        }
    }
}
