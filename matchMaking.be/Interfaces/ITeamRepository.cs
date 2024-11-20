using matchMaking.be.Models;

namespace matchMaking.be.Interfaces;

public interface ITeamRepository
{
    Task<Team?> GetTeamByName(string teamName);
    Task<Team?> CreateTeam(Team team);

    Task<Team?> GetTeamById(Guid teamId);
}