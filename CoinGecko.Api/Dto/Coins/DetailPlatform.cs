using System.Text.Json.Serialization;

namespace CoinGecko.Api.Dto.Coins;

public class DetailPlatform
{
    [JsonPropertyName("decimal_place")]
    public int? DecimalPlace { get; set; }

    [JsonPropertyName("contract_address")]
    public string ContractAddress { get; set; } = null!;
}