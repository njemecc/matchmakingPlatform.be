using matchMaking.be.Context;
using matchMaking.be.Interfaces;
using matchMaking.be.Models;
using Microsoft.EntityFrameworkCore;

namespace matchMaking.be.Repository;

public class TeamRepository:ITeamRepository
{
    
    private readonly MatchmakingContext _context;

    public TeamRepository(MatchmakingContext context)
    {
        _context = context;
    }

    public async Task<Team?> GetTeamByName(string teamName)
    {
        return await _context.Teams.Include(t => t.Players)
            .FirstOrDefaultAsync(t => t.TeamName == teamName);
    }   

    public async Task<Team?> CreateTeam(Team team)
    {
        await _context.Teams.AddAsync(team);
        await _context.SaveChangesAsync();
        return team;
    }
    
    
    public async Task<Team?> GetTeamById(Guid teamId)
    {
       
        return await _context.Teams
            .Include(t => t.Players).FirstOrDefaultAsync(t => t.Id == teamId);
    }
}

internal class ApplicationDbContext
{
}