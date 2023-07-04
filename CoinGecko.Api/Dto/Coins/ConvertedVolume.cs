using System.Text.Json.Serialization;

namespace CoinGecko.Api.Dto.Coins;

public class ConvertedVolume
{
    [JsonPropertyName("btc")]
    public double Btc { get; set; }

    [JsonPropertyName("eth")]
    public double Eth { get; set; }

    [JsonPropertyName("usd")]
    public double Usd { get; set; }
}