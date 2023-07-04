using System.Text.Json.Serialization;

namespace CoinGecko.Api.Dto.Coins;

public class Ticker
{
    [JsonPropertyName("base")]
    public string Base { get; set; } = null!;

    [JsonPropertyName("target")]
    public string Target { get; set; } = null!;

    [JsonPropertyName("market")]
    public Market Market { get; set; } = null!;

    [JsonPropertyName("last")]
    public double Last { get; set; }

    [JsonPropertyName("volume")]
    public float Volume { get; set; }

    [JsonPropertyName("converted_last")]
    public ConvertedLast ConvertedLast { get; set; } = null!;

    [JsonPropertyName("converted_volume")]
    public ConvertedVolume ConvertedVolume { get; set; } = null!;

    [JsonPropertyName("trust_score")]
    public string TrustScore { get; set; } = null!;

    [JsonPropertyName("bid_ask_spread_percentage")]
    public double? BidAskSpreadPercentage { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; set; }

    [JsonPropertyName("last_traded_at")]
    public DateTime LastTradedAt { get; set; }

    [JsonPropertyName("last_fetch_at")]
    public DateTime LastFetchAt { get; set; }

    [JsonPropertyName("is_anomaly")]
    public bool IsAnomaly { get; set; }

    [JsonPropertyName("is_stale")]
    public bool IsStale { get; set; }

    [JsonPropertyName("trade_url")]
    public string TradeUrl { get; set; } = null!;

    [JsonPropertyName("token_info_url")]
    public object TokenInfoUrl { get; set; } = null!;

    [JsonPropertyName("coin_id")]
    public string CoinId { get; set; } = null!;

    [JsonPropertyName("target_coin_id")]
    public string TargetCoinId { get; set; } = null!;
}