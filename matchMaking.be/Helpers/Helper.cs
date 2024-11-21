namespace matchMaking.be.Helpers;

public static class Helper
{
    public static int KCalculaiton(int hoursPlayed)
    {
        if (hoursPlayed < 500) return 50;
        if (hoursPlayed < 1000) return 40;
        if (hoursPlayed < 3000) return 30;
        if (hoursPlayed < 5000) return 20;
        return 10;
    }
}