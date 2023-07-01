using System.Text.Json.Serialization;

public class CoinMarketDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("current_price")]
    public double CurrentPrice { get; set; }

    [JsonPropertyName("market_cap")]
    public float MarketCap { get; set; }

    [JsonPropertyName("market_cap_rank")]
    public int? MarketCapRank { get; set; }

    [JsonPropertyName("fully_diluted_valuation")]
    public double FullyDilutedValuation { get; set; }

    [JsonPropertyName("total_volume")]
    public double TotalVolume { get; set; }

    [JsonPropertyName("high_24h")]
    public double High24h { get; set; }

    [JsonPropertyName("low_24h")]
    public double Low24h { get; set; }

    [JsonPropertyName("price_change_24h")]
    public double PriceChange24h { get; set; }

    [JsonPropertyName("price_change_percentage_24h")]
    public double PriceChangePercentage24h { get; set; }

    [JsonPropertyName("market_cap_change_24h")]
    public double MarketCapChange24h { get; set; }

    [JsonPropertyName("market_cap_change_percentage_24h")]
    public double MarketCapChangePercentage24h { get; set; }

    [JsonPropertyName("circulating_supply")]
    public double CirculatingSupply { get; set; }

    [JsonPropertyName("total_supply")]
    public double TotalSupply { get; set; }

    [JsonPropertyName("max_supply")]
    public double? MaxSupply { get; set; }

    [JsonPropertyName("ath")]
    public double Ath { get; set; }

    [JsonPropertyName("ath_change_percentage")]
    public double AthChangePercentage { get; set; }

    [JsonPropertyName("ath_date")]
    public DateTime AthDate { get; set; }

    [JsonPropertyName("atl")]
    public double Atl { get; set; }

    [JsonPropertyName("atl_change_percentage")]
    public double AtlChangePercentage { get; set; }

    [JsonPropertyName("atl_date")]
    public DateTime AtlDate { get; set; }

    [JsonPropertyName("roi")]
    public object Roi { get; set; }

    [JsonPropertyName("last_updated")]
    public DateTime LastUpdated { get; set; }

    [JsonPropertyName("price_change_percentage_1h_in_currency")]
    public float PriceChangePercentage1hInCurrency { get; set; }
}