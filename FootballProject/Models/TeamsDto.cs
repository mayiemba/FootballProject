using System.Text.Json.Serialization;

namespace FootballProject.Models
{
    public class TeamsDto
    {
        [JsonPropertyName("team_id")]
        public int Id { get; set; }
        public string TeamName { get; set; }= string.Empty;
        public string Manager { get; set; } = string.Empty;
    }
}