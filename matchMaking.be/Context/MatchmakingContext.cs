using System.Text.RegularExpressions;
using matchMaking.be.Models;
using Microsoft.EntityFrameworkCore;
using Match = matchMaking.be.Models.Match;

namespace matchMaking.be.Context;

public class MatchmakingContext: DbContext
{

    public MatchmakingContext(DbContextOptions<MatchmakingContext> options):base(options)
    {
        
    }
    
    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }
    
    public DbSet<Match> Matches { get; set; }
    
}