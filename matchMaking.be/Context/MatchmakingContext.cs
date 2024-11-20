using System.Text.RegularExpressions;
using matchMaking.be.Models;
using Microsoft.EntityFrameworkCore;

namespace matchMaking.be.Context;

public class MatchmakingContext: DbContext
{

    public MatchmakingContext(DbContextOptions<MatchmakingContext> options):base(options)
    {
        
    }
    
    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }
    
}