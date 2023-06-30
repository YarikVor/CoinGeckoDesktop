using System.Collections.Specialized;
using System.Text.Json.Serialization;

namespace CoinGecko.Api.Dto.Coins;

public class CoinsItemDto
{
    public string Id { get; set; } = null!;
    public string Symbol { get; set; } = null!;
    public string Name { get; set; } = null!;
}