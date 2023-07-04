namespace CoinGecko.Api;

internal static class Ex
{
    public static string ToLowerString(this bool boolean)
    {
        return boolean ? "true" : "false";
    }
}