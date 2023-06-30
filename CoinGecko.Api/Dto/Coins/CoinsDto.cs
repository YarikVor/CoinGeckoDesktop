namespace CoinGecko.Api.Dto.Coins;

public class CoinsDto : CoinsItemWithPlatformsDto
{
    public Dictionary<string, DetailPlatform> DetailPlatforms { get; set; }
    public int BlockTimeInMinutes { get; set; }
    public string? HashingAlgorithm { get; set; }

    public string[] Categories { get; set; }

    //TODO: type isn't know
    public object? PublicNotice { get; set; }
    public object[] AdditionalNotices { get; set; }
    public Dictionary<string, string> Localization { get; set; }
    public Dictionary<string, string> Description { get; set; }
    public Links Links { get; set; }
    public Image Image { get; set; }
    public string CountryJrigin { get; set; }
    public object GenesisDate { get; set; }
    public string ContractAddress { get; set; }
    public object SentimentVotesUpPercentage { get; set; }
    public object SentimentVotesDownPercentage { get; set; }
    public int WatchlistPortfolioUsers { get; set; }
    public object MarketCapRank { get; set; }
    public int CoingeckoRank { get; set; }
    public double CoingeckoScore { get; set; }
    public int DeveloperScore { get; set; }
    public double CommunityScore { get; set; }
    public int LiquidityScore { get; set; }
    public int PublicInterestScore { get; set; }
    public MarketData MarketData { get; set; }
    public CommunityData CommunityData { get; set; }
    public DeveloperData DeveloperData { get; set; }
    public PublicInterestStats PublicInterestStats { get; set; }
    public object[] StatusUpdates { get; set; }
    public DateTime LastUpdated { get; set; }
    public Tickers[] Tickers { get; set; }
}