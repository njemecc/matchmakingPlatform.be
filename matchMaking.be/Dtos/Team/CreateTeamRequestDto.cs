using matchMaking.be.Models;

namespace matchMaking.be.Dtos.Team;

public class CreateTeamRequestDto
{
    public string TeamName { get; set; }
    
    public List<Guid> Players { get; set; }
}