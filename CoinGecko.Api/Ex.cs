namespace CoinGecko.Api;

public static class Ex
{
    public static string ToLowerString(this bool boolean)
    {
        return boolean ? "true" : "false";
    }
}