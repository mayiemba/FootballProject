using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballProject.Entities
{
 
    public class Team
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string TeamName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Manager { get; set; } = string.Empty; 
    }
}
