using matchMaking.be.Models;

namespace matchMaking.be.Interfaces;

public interface IMatchRepository
{
    Task AddMatchAsync(Match match);
}