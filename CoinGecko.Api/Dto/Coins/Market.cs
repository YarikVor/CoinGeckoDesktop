using System.Text.Json.Serialization;

namespace CoinGecko.Api.Dto.Coins;

public class Market
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("identifier")]
    public string Identifier { get; set; } = null!;

    [JsonPropertyName("has_trading_incentive")]
    public bool HasTradingIncentive { get; set; }
}