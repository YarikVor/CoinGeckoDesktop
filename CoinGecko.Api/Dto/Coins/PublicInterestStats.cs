using System.Text.Json.Serialization;

namespace CoinGecko.Api.Dto.Coins;

public class PublicInterestStats
{
    [JsonPropertyName("alexa_rank")]
    public int? AlexaRank { get; set; }

    [JsonPropertyName("bing_matches")]
    public object? BingMatches { get; set; }
}