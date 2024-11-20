using matchMaking.be.Context;
using matchMaking.be.Interfaces;
using matchMaking.be.Models;

namespace matchMaking.be.Repository;

public class MatchRepository : IMatchRepository
{

    private readonly MatchmakingContext _matchmakingContext;

    public MatchRepository(MatchmakingContext matchmakingContext)
    {
        _matchmakingContext = matchmakingContext;
    }


    public async Task AddMatchAsync(Match match)
    {
        await _matchmakingContext.AddAsync(match);
        await _matchmakingContext.SaveChangesAsync();
    }
}