namespace matchMaking.be.Dtos.Match;

public class CreateMatchRequestDto
{
   
        public Guid Team1Id { get; set; } 
        public Guid Team2Id { get; set; } 
        public Guid? WinningTeamId { get; set; } 
        public int Duration { get; set; } 
    }

