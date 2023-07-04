using YarikVor.QueryFormatting;

namespace CoinGecko.Api.Requests;

public class CoinRequest
{
    [QueryPropertyName("id")]
    public string Id { get; set; } = null!;

    [QueryPropertyName("localization")]
    public bool Localization { get; set; } = true;

    [QueryPropertyName("tickers")]
    public bool Tickers { get; set; } = true;

    [QueryPropertyName("market_data")]
    public bool MarketData { get; set; } = true;

    [QueryPropertyName("community_data")]
    public bool CommunityData { get; set; } = true;

    [QueryPropertyName("developer_data")]
    public bool DeveloperData { get; set; } = true;

    [QueryPropertyName("sparkline")]
    public bool Sparkline { get; set; } = false;
}