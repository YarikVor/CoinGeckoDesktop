using System.Text.Json.Serialization;

namespace CoinGecko.Api.Dto.Coins;

public class MarketData
{
    [JsonPropertyName("current_price")]
    public Dictionary<string, float> CurrentPrice { get; set; } = null!;

    [JsonPropertyName("total_value_locked")]
    public object? TotalValueLocked { get; set; }

    [JsonPropertyName("mcap_to_tvl_ratio")]
    public object? McapToTvlRatio { get; set; }

    [JsonPropertyName("fdv_to_tvl_ratio")]
    public object? FdvToTvlRatio { get; set; }

    [JsonPropertyName("roi")]
    public object? Roi { get; set; }

    [JsonPropertyName("ath")]
    public Dictionary<string, float> Ath { get; set; } = null!;

    [JsonPropertyName("ath_change_percentage")]
    public Dictionary<string, float> AthChangePercentage { get; set; } = null!;

    [JsonPropertyName("ath_date")]
    public Dictionary<string, DateTime> AthDate { get; set; } = null!;

    [JsonPropertyName("atl")]
    public Dictionary<string, float> Atl { get; set; } = null!;

    [JsonPropertyName("atl_change_percentage")]
    public Dictionary<string, float> AtlChangePercentage { get; set; } = null!;

    [JsonPropertyName("atl_date")]
    public Dictionary<string, DateTime> AtlDate { get; set; } = null!;

    [JsonPropertyName("market_cap")]
    public Dictionary<string, float> MarketCap { get; set; } = null!;

    [JsonPropertyName("market_cap_rank")]
    public object MarketCapRank { get; set; } = null!;

    [JsonPropertyName("fully_diluted_valuation")]
    public Dictionary<string, float> FullyDilutedValuation { get; set; } = null!;

    [JsonPropertyName("total_volume")]
    public Dictionary<string, float> TotalVolume { get; set; } = null!;

    [JsonPropertyName("high_24h")]
    public Dictionary<string, float?> High24H { get; set; } = null!;

    [JsonPropertyName("low_24h")]
    public Dictionary<string, float?> Low24H { get; set; } = null!;

    [JsonPropertyName("price_change_24h")]
    public double? PriceChange24H { get; set; }

    [JsonPropertyName("price_change_percentage_24h")]
    public float? PriceChangePercentage24H { get; set; }

    [JsonPropertyName("price_change_percentage_7d")]
    public float PriceChangePercentage7d { get; set; }

    [JsonPropertyName("price_change_percentage_14d")]
    public float PriceChangePercentage14d { get; set; }

    [JsonPropertyName("price_change_percentage_30d")]
    public float PriceChangePercentage30d { get; set; }

    [JsonPropertyName("price_change_percentage_60d")]
    public float PriceChangePercentage60d { get; set; }

    [JsonPropertyName("price_change_percentage_200d")]
    public float PriceChangePercentage200d { get; set; }

    [JsonPropertyName("price_change_percentage_1y")]
    public float PriceChangePercentage1Y { get; set; }

    [JsonPropertyName("market_cap_change_24h")]
    public float? MarketCapChange24H { get; set; }

    [JsonPropertyName("market_cap_change_percentage_24h")]
    public float? MarketCapChangePercentage24H { get; set; }

    [JsonPropertyName("price_change_24h_in_currency")]
    public Dictionary<string, float> PriceChange24HInCurrency { get; set; } = null!;

    [JsonPropertyName("price_change_percentage_1h_in_currency")]
    public Dictionary<string, float> PriceChangePercentage1HInCurrency { get; set; } = null!;

    [JsonPropertyName("price_change_percentage_24h_in_currency")]
    public Dictionary<string, float> PriceChangePercentage24HInCurrency { get; set; } = null!;

    [JsonPropertyName("price_change_percentage_7d_in_currency")]
    public Dictionary<string, float> PriceChangePercentage7dInCurrency { get; set; } = null!;

    [JsonPropertyName("price_change_percentage_14d_in_currency")]
    public Dictionary<string, float> PriceChangePercentage14dInCurrency { get; set; } = null!;

    [JsonPropertyName("price_change_percentage_30d_in_currency")]
    public Dictionary<string, float> PriceChangePercentage30dInCurrency { get; set; } = null!;

    [JsonPropertyName("price_change_percentage_60d_in_currency")]
    public Dictionary<string, float> PriceChangePercentage60dInCurrency { get; set; } = null!;

    [JsonPropertyName("price_change_percentage_200d_in_currency")]
    public Dictionary<string, float> PriceChangePercentage200dInCurrency { get; set; } = null!;

    [JsonPropertyName("price_change_percentage_1y_in_currency")]
    public Dictionary<string, float> PriceChangePercentage1YInCurrency { get; set; } = null!;

    [JsonPropertyName("market_cap_change_24h_in_currency")]
    public Dictionary<string, float> MarketCapChange24HInCurrency { get; set; } = null!;

    [JsonPropertyName("market_cap_change_percentage_24h_in_currency")]
    public Dictionary<string, float> MarketCapChangePercentage24HInCurrency { get; set; } = null!;

    [JsonPropertyName("total_supply")]
    public float? TotalSupply { get; set; }

    [JsonPropertyName("max_supply")]
    public object? MaxSupply { get; set; }

    [JsonPropertyName("circulating_supply")]
    public float CirculatingSupply { get; set; }

    [JsonPropertyName("last_updated")]
    public DateTime LastUpdated { get; set; }
}