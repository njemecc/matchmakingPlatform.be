using matchMaking.be.Dtos.Match;
using matchMaking.be.Models;

namespace matchMaking.be.Interfaces;

public interface IMatchService
{
    Task<Match> AddMatch(CreateMatchRequestDto createMatchRequestDto);
}