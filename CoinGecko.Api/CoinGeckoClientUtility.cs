using System.Text.Json;

namespace CoinGecko.Api;

public static class CoinGeckoClientUtility
{
    public static readonly JsonSerializerOptions JsonSerializerOptions
        = new()
        {
            PropertyNameCaseInsensitive = true
        };
}