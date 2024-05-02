using FootballProject.DbContexts;
using FootballProject.Entities;

namespace FootballProject.Repositories
{
    public class TeamRepository
    {
        private readonly TeamInfoContext _context;
        public TeamRepository(TeamInfoContext context)
        {
            _context = context;
        }


        public List<Team> GetAllTeams()
        {
            var teams = _context.Teams.ToList();

            return teams;
        }

        public Team GetTeam(int id)
        { 
            var team = _context.Teams.Where(t => t.Id == id).FirstOrDefault();

            return team;
        }

        public Team GetTeamByName(string teamName)
        {
            var team = _context.Teams.Where(t => t.TeamName == teamName).FirstOrDefault();

            return team;
        }

        public Team GetTeamByManager(string Manager)
        {
            var team = _context.Teams.Where(t => t.Manager == Manager).FirstOrDefault();

            return team;
        }

        public Team Create(Team team)
        {
            _context.Teams.Add(team);

            _context.SaveChanges();

            return team;
        }

        public Team Update(Team team)
        {
            _context.Teams.Update(team);

            _context.SaveChanges();

            return team;
        }

        public Team Delete(Team team)
        {
            _context.Teams.Remove(team);

            _context.SaveChanges();

            return team;
        }

        public List<Team> DeleteAllTeams()
        {
            var teams = _context.Teams.ToList();

            _context.Teams.RemoveRange(teams);

            _context.SaveChanges();

            return teams;
        }
    }
}

