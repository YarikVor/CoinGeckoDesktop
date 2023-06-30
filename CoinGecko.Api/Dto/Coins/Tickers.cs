namespace CoinGecko.Api.Dto.Coins;

public class Tickers
{
    public string Base { get; set; }
    public string Target { get; set; }
    public Market Market { get; set; }
    public float Last { get; set; }
    public float Volume { get; set; }
    public Converted ConvertedLast { get; set; }
    public Converted ConvertedVolume { get; set; }
    public string TrustScore { get; set; }
    public float BidAskSpreadPercentage { get; set; }
    public DateTime Timestamp { get; set; }
    public DateTime LastTradedAt { get; set; }
    public DateTime LastFetchAt { get; set; }
    public bool IsAnomaly { get; set; }
    public bool IsStale { get; set; }
    public string TradeUrl { get; set; }
    public object TokenInfoUrl { get; set; }
    public string CoinId { get; set; }
    public string TargetCoinId { get; set; }
}