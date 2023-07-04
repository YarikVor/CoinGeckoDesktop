using System.Text.Json.Serialization;

namespace CoinGecko.Api.Dto.Coins;

public class Image
{
    [JsonPropertyName("thumb")]
    public string Thumb { get; set; } = null!;

    [JsonPropertyName("small")]
    public string Small { get; set; } = null!;

    [JsonPropertyName("large")]
    public string Large { get; set; } = null!;
}