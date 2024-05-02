using FootballProject.Entities;
using FootballProject.Models;
using FootballProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FootballProject.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamsController : ControllerBase
    {
        private readonly TeamsDataStore _teamsDataStore;
        private readonly TeamRepository _teamRepository;
        private readonly Random _random = new Random();

        public TeamsController(TeamsDataStore teamsDataStore, TeamRepository teamRepository)
        {
            _teamsDataStore = teamsDataStore ?? throw new ArgumentNullException(nameof(teamsDataStore));
            _teamRepository = teamRepository ?? throw new ArgumentNullException();
        }

        [HttpGet("getTeams")]
        public ActionResult<Team> GetAllTeams()
        {
            var teamResult = _teamRepository.GetAllTeams();
            if (teamResult == null)
            {
                return NotFound("No teams listed");
            }
            return Ok(teamResult);
        }

        [HttpGet("getTeamById/{id}")]
        public ActionResult<Team> GetTeam(int id)
        {
            var teamResult = _teamRepository.GetTeam(id);
            if (teamResult == null)
            {
                return NotFound("Team not found");
            }
            return Ok(teamResult);
        }

        [HttpGet("getTeamByName/{teamName}")]
        public ActionResult<Team> GetTeamByNAme(string teamName) 
        {
            var teamResult = _teamRepository.GetTeamByName(teamName);
            if (teamResult == null)
            {
                return NotFound("There's no team with that name.");
            }
            return Ok(teamResult);
        }

        [HttpGet("getTeamByManager/{Manager}")]
        public ActionResult<Team> GetTeamByManager(string Manager)
        {
            var teamResult = _teamRepository.GetTeamByManager(Manager);
            if (teamResult == null)
            {
                return NotFound("Manager doesn't belong to any team.");
            }
            return Ok(teamResult);
        }

        [HttpPost("createTeam")]
        public ActionResult<Team>CreateTeam(Team team)
        {
            var teamResult = _teamRepository.Create(team);
            if (teamResult == null) 
            {
                return NotFound();
            }
            return Ok(teamResult);
        }

        [HttpPost("updateTeam")]
        public ActionResult<Team> UpdateTeam(Team team)
        {
            var teamResult = _teamRepository.Update(team);
            if (teamResult == null)
            {
                return NotFound();
            }
            return Ok(teamResult);
        }

        [HttpDelete("removeTeam")]
        public ActionResult<Team> RemoveTeam(Team team)
        {
            var teamResult = _teamRepository.Delete(team);
            if (teamResult == null)
            {
                return NotFound();
            }
            return Ok(teamResult);
        }

        [HttpDelete("deleteTeams")]
        public ActionResult<Team> DeleteAllTeams()
        {
            var teamResult = _teamRepository.DeleteAllTeams();
            if (teamResult == null)
            {
                return NotFound("Failed to delete all teams");
            }
            return Ok("Teams successfully deleted.");
        }

        [HttpGet("getHomeTeam/{id}")]
        public ActionResult<Team> GetHomeTeam(int id)
        {
            var matchResult = _teamRepository.GetTeam(id);
            if (matchResult == null)
            {
                return NotFound("Team not found");
            }
            return Ok(matchResult);
        }


        [HttpGet("getAwayTeam/{id}")]
        public ActionResult<Team> GetAwayTeam(int id)
        {
            var matchResult = _teamRepository.GetTeam(id);
            if (matchResult == null)
            {
                return NotFound("Team not found");
            }
            return Ok(matchResult);
        }


        [HttpGet]
        public ActionResult<IEnumerable<TeamsDto>> GetTeams()
        {
            return Ok(TeamsDataStore.Current.Teams);
        }

        //[HttpGet("{id}")]
        //public ActionResult<TeamsDto> GetTeam(int id) 
        //{
        //    //find team
        //    var teamToReturn = _teamsDataStore.Teams.FirstOrDefault(t => t.Id == id);

        //    if (teamToReturn == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(teamToReturn);

        //   /* return new JsonResult(
        //        TeamsDataStore.Current.Teams.FirstOrDefault(t => t.Id == id));*/
        //}
    }
}
