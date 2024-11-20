namespace matchMaking.be.Exceptions;

public class PlayerAlredyExistsException:Exception
{
    public PlayerAlredyExistsException(string message) : base(message) { }
}