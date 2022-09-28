using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tournament_manager_backend.Data;
using tournament_manager_backend.Models;

namespace tournament_manager_backend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IPlayerRepository _playerRepository;
        private const int RACE_TO = 10;

        public MatchController(IMatchRepository matchRepository, IPlayerRepository playerRepository)
        {
            _matchRepository = matchRepository;
            _playerRepository = playerRepository;
        }

        [HttpPost("AddAutomaticMatch/{playerId1}/{playerId2}")]
        public void AddAutomaticMatch(int playerId1, int playerId2)
        {
            Player player1 = _playerRepository.GetById(playerId1);
            Player player2 = _playerRepository.GetById(playerId2);

            Random random1 = new Random();
            Random random2 = new Random();
            int player1Score = 0;
            int player2Score = 0;
            int randomPower1 = random1.Next(1, 11) + player1.Power;
            int randomPower2 = random2.Next(1, 11) + player2.Power;

            while (player1Score < 10 && player2Score < 10)
            {
                if (randomPower1 > randomPower2)
                {
                    player1Score++;
                }
                if (randomPower1 < randomPower2)
                {
                    player2Score++;
                }
                randomPower1 = random1.Next(1, 11) + player1.Power;
                randomPower2 = random2.Next(1, 11) + player2.Power;
            }

            var winRecord = new WinRecord();
            var lossRecord = new LossRecord();
            int ratingChange = CalculateRatingChange(player1.Rating, 
                                                     player2.Rating, 
                                                     player1Score, 
                                                     player2Score);

            if (player1Score > player2Score)
            {
                winRecord.Opponent = player2.Name;
                winRecord.WinnerScore = player1Score;
                winRecord.LosserScore = player2Score;
                winRecord.Player = player1;

                lossRecord.Opponent = player1.Name;
                lossRecord.WinnerScore = player1Score;
                lossRecord.LosserScore = player2Score;
                lossRecord.Player = player2;

                player1.Rating = player1.Rating + ratingChange;
                player2.Rating = player2.Rating - ratingChange;
            }
            if (player1Score < player2Score)
            {
                lossRecord.Opponent = player2.Name;
                lossRecord.WinnerScore = player2Score;
                lossRecord.LosserScore = player1Score;
                lossRecord.Player = player1;

                winRecord.Opponent = player1.Name;
                winRecord.WinnerScore = player2Score;
                winRecord.LosserScore = player1Score;
                winRecord.Player = player2;

                player2.Rating = player2.Rating + ratingChange;
                player1.Rating = player1.Rating - ratingChange;
            }

            _playerRepository.UpdateRating(playerId1, player1.Rating);
            _playerRepository.UpdateRating(playerId2, player2.Rating);
            _matchRepository.AddMatchResult(winRecord, lossRecord);
        }

        [HttpPost("AddManualMatch/{winnerId}/{loserId}")]
        public void AddManualMatch(int winnerId, int loserId)
        {
            Player winner = _playerRepository.GetById(winnerId);
            Player loser = _playerRepository.GetById(loserId);

            var winRecord = new WinRecord();
            var lossRecord = new LossRecord();

            int ratingChange = CalculateRatingChange(winner.Rating,
                                         loser.Rating,
                                         1,
                                         0);

            winRecord.Opponent = loser.Name;
            winRecord.WinnerScore = 1;
            winRecord.LosserScore = 0;
            winRecord.Player = winner;

            lossRecord.Opponent = winner.Name;
            lossRecord.WinnerScore = 1;
            lossRecord.LosserScore = 0;
            lossRecord.Player = loser;

            winner.Rating = winner.Rating + ratingChange;
            loser.Rating = loser.Rating - ratingChange;

            _matchRepository.AddMatchResult(winRecord, lossRecord);
        }

        public int CalculateRatingChange(int rating1, int rating2, int score1, int score2)
        {
            double transformedRating1 = Math.Pow(10.0, rating1 / 400.0);
            double transformedRating2 = Math.Pow(10.0, rating2 / 400.0);

            double expectedScore1 = transformedRating1 / (transformedRating1 + transformedRating2);
            double expectedScore2 = transformedRating2 / (transformedRating2 + transformedRating1);

            double change = 0;

            if (score1 > score2)
            {
                change = 100 * (1 - expectedScore1);
            }
            if (score1 < score2)
            {
                change = 100 * (1 - expectedScore2);
            }

            return (int) change;
        }
    }
}
