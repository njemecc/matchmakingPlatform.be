using System.ComponentModel.DataAnnotations;

namespace matchMaking.be.Models;

public class Team
{
    [Key]
    
    public Guid Id { get; set; }
    
    public string TeamName { get; set; }
    
    public ICollection<Player> Players { get; set; }
    
}