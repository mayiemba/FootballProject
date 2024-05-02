using System.Text.Json.Serialization;

namespace FootballProject.Models
{
    public class MatchDto
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId {  get; set; } 
        public string Description { get; set; } = string.Empty;
    }
}
