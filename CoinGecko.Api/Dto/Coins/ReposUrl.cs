using System.Text.Json.Serialization;

namespace CoinGecko.Api.Dto.Coins;

public class ReposUrl
{
    [JsonPropertyName("github")]
    public List<string> Github { get; set; } = null!;

    [JsonPropertyName("bitbucket")]
    public List<object?> Bitbucket { get; set; } = null!;
}