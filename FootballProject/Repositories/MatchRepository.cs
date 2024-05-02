using FootballProject.DbContexts;
using FootballProject.Entities;

namespace FootballProject.Repositories
{
    public class MatchRepository
    {
        private readonly TeamInfoContext _context;
        public MatchRepository(TeamInfoContext context)
        {
            _context = context;
        }

        public Match Create(Match match)
        {
            _context.Matches.Add(match);

            _context.SaveChanges();

            return match;
        }

        public Match GetMatch(int id)
        {
            var match = _context.Matches.Where(m => m.Id == id).FirstOrDefault();

            return match;
        }
    }
}
