using FootballProject.Entities;
using FootballProject.Models;
using FootballProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FootballProject.Controllers
{
    [ApiController]
    [Route("api/matches")]
    public class MatchesController : ControllerBase
    {
        private readonly MatchRepository _matchRepository;
        private readonly TeamRepository _teamRepository;
        private readonly Random _random = new Random();

        public MatchesController(MatchRepository matchRepository, TeamRepository teamRepository)
        {
            _matchRepository = matchRepository ?? throw new ArgumentNullException();
            _teamRepository = teamRepository ?? throw new ArgumentNullException();
        }

        [HttpGet("createMatch")]
        public ActionResult<Team> CreateMatch(MatchDto request) 
        {
            //validations 
            var homeTeamExists = _teamRepository.GetTeam(request.HomeTeamId);

            if (homeTeamExists == null)
            {
                return NotFound("Home team with specified ID not found");
            }

            var awayTeamExists = _teamRepository.GetTeam(request.AwayTeamId);

            if (awayTeamExists == null)
            {
                return NotFound("Home team with specified ID not found");
            }


            var newMatch = new Match
            {
                HomeTeam = homeTeamExists,
                AwayTeam = awayTeamExists,
               /* HomeTeamId = homeTeamId,
                AwayTeamId = awayTeamId,
                Description = description,*/
                HomeGoals = _random.Next(0, 10),
                AwayGoals = _random.Next(0, 10),
            };

            var matchResult = _matchRepository.Create(newMatch);
            if (matchResult == null)
            {
                return NotFound();
            }
            return Ok(matchResult);
        }

        [HttpGet("getMatch/{id}")]
        public ActionResult<Match> GetMatch(int id)
        {
            var matchResult = _matchRepository.GetMatch(id);
            if (matchResult == null)
            {
                return NotFound("Match not found");
            }
            return Ok(matchResult);
        }
    }
}

