using System.Text.Json.Serialization;

namespace CoinGecko.Api.Dto.Coins;

public class CodeAdditionsDeletions4Weeks
{
    [JsonPropertyName("additions")]
    public int? Additions { get; set; }

    [JsonPropertyName("deletions")]
    public int? Deletions { get; set; }
}