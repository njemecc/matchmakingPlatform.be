using System.ComponentModel.DataAnnotations;

namespace matchMaking.be.Models;

public class Match
{
    [Key]
    public Guid Id { get; set; }
    public Guid Team1Id { get; set; }
    public Team Team1 { get; set; }
    public Guid Team2Id { get; set; }
    public Team Team2 { get; set; }
    public Guid? WinningTeamId { get; set; }
    public Team WinningTeam { get; set; }
    public int Duration { get; set; }
}