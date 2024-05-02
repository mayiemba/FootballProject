using FootballProject.Models;

namespace FootballProject
{
    public class TeamsDataStore
    {
        public List<TeamsDto> Teams { get; set; }
        public static TeamsDataStore Current { get; } = new TeamsDataStore();

        public TeamsDataStore() 
        {
            Teams = new List<TeamsDto>()
            {
                new  TeamsDto()
                {
                    Id = 1,
                    TeamName = "Man City",
                    Manager = "Pep Guardiola"   
                },
                new TeamsDto()
                {
                    Id= 2,
                    TeamName ="Man United",
                    Manager = "Alex Ferguson"
                },
                new TeamsDto()
                {
                    Id = 3,
                    TeamName = "Leeds",
                    Manager = "Daniel Farke"
                },
                new TeamsDto()
                {
                    Id = 4,
                    TeamName = "Spurs",
                    Manager = "Ange Postecoglou"
                },
                new TeamsDto()
                {
                    Id = 5,
                    TeamName = "Newcastle",
                    Manager = "Eddie Howe"                    
                }
            };
        }
    }
}
