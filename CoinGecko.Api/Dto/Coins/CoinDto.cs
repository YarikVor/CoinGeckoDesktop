using System.Text.Json.Serialization;

namespace CoinGecko.Api.Dto.Coins;

public class CoinDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("asset_platform_id")]
    public object? AssetPlatformId { get; set; }

    [JsonPropertyName("platforms")]
    public Dictionary<string, string> Platforms { get; set; } = null!;

    [JsonPropertyName("detail_platforms")]
    public Dictionary<string, DetailPlatform> DetailPlatforms { get; set; } = null!;

    [JsonPropertyName("block_time_in_minutes")]
    public int BlockTimeInMinutes { get; set; }

    [JsonPropertyName("hashing_algorithm")]
    public string? HashingAlgorithm { get; set; }

    [JsonPropertyName("categories")]
    public List<string> Categories { get; set; } = null!;

    [JsonPropertyName("public_notice")]
    public object? PublicNotice { get; set; }

    [JsonPropertyName("additional_notices")]
    public List<object>? AdditionalNotices { get; set; }

    [JsonPropertyName("localization")]
    public Dictionary<string, string> Localization { get; set; } = null!;

    [JsonPropertyName("description")]
    public Dictionary<string, string> Description { get; set; } = null!;

    [JsonPropertyName("links")]
    public Links Links { get; set; } = null!;

    [JsonPropertyName("image")]
    public Image Image { get; set; } = null!;

    [JsonPropertyName("country_origin")]
    public string CountryOrigin { get; set; } = null!;

    [JsonPropertyName("genesis_date")]
    public object GenesisDate { get; set; } = null!;

    [JsonPropertyName("sentiment_votes_up_percentage")]
    public object SentimentVotesUpPercentage { get; set; } = null!;

    [JsonPropertyName("sentiment_votes_down_percentage")]
    public object SentimentVotesDownPercentage { get; set; } = null!;

    [JsonPropertyName("watchlist_portfolio_users")]
    public int WatchlistPortfolioUsers { get; set; }

    [JsonPropertyName("market_cap_rank")]
    public object MarketCapRank { get; set; } = null!;

    [JsonPropertyName("coingecko_rank")]
    public int? CoingeckoRank { get; set; } = null!;

    [JsonPropertyName("coingecko_score")]
    public double CoingeckoScore { get; set; }

    [JsonPropertyName("developer_score")]
    public double DeveloperScore { get; set; }

    [JsonPropertyName("community_score")]
    public double CommunityScore { get; set; }

    [JsonPropertyName("liquidity_score")]
    public float LiquidityScore { get; set; }

    [JsonPropertyName("public_interest_score")]
    public float PublicInterestScore { get; set; }

    [JsonPropertyName("market_data")]
    public MarketData MarketData { get; set; } = null!;

    [JsonPropertyName("community_data")]
    public CommunityData CommunityData { get; set; } = null!;

    [JsonPropertyName("developer_data")]
    public DeveloperData DeveloperData { get; set; } = null!;

    [JsonPropertyName("public_interest_stats")]
    public PublicInterestStats PublicInterestStats { get; set; } = null!;

    [JsonPropertyName("status_updates")]
    public List<object> StatusUpdates { get; set; } = null!;

    [JsonPropertyName("last_updated")]
    public DateTime LastUpdated { get; set; }

    [JsonPropertyName("tickers")]
    public List<Ticker> Tickers { get; set; } = null!;
}