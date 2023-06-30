namespace CoinGecko.Api.Dto.Coins;

public class MarketData
{
    public Dictionary<string, float> CurrentPrice { get; set; }
    public Dictionary<string, float> TotalValueLocked { get; set; }
    public int McapToTvlRatio { get; set; }
    public float FdvToTvlRatio { get; set; }
    public object Roi { get; set; }
    public Dictionary<string, float> Ath { get; set; }
    public Dictionary<string, float> AthChangePercentage { get; set; }
    public Dictionary<string, DateTime> AthDate { get; set; }
    public Dictionary<string, float> Atl { get; set; }
    public Dictionary<string, float> AtlChangePercentage { get; set; }
    public Dictionary<string, DateTime> AtlDate { get; set; }
    public Dictionary<string, float> MarketCap { get; set; }
    public object MarketCapRank { get; set; }
    public Dictionary<string, float> FullyDilutedValuation { get; set; }
    public Dictionary<string, float> TotalVolume { get; set; }
    public Dictionary<string, float> High24H { get; set; }
    public Dictionary<string, float> Low24H { get; set; }
    public float PriceChange24H { get; set; }
    public float PriceChangePercentage24H { get; set; }
    public float PriceChangePercentage7D { get; set; }
    public float PriceChangePercentage14D { get; set; }
    public float PriceChangePercentage30D { get; set; }
    public float PriceChangePercentage60D { get; set; }
    public float PriceChangePercentage200D { get; set; }
    public float PriceChangePercentage1Y { get; set; }
    public int MarketCapChange24H { get; set; }
    public int MarketCapChangePercentage24H { get; set; }
    public Dictionary<string, float> PriceChange24HInCurrency { get; set; }
    public Dictionary<string, float> PriceChangePercentage1HInCurrency { get; set; }
    public Dictionary<string, float> PriceChangePercentage24HInCurrency { get; set; }
    public Dictionary<string, float> PriceChangePercentage7DInCurrency { get; set; }
    public Dictionary<string, float> PriceChangePercentage14DInCurrency { get; set; }
    public Dictionary<string, float> PriceChangePercentage30DInCurrency { get; set; }
    public Dictionary<string, float> PriceChangePercentage60DInCurrency { get; set; }
    public Dictionary<string, float> PriceChangePercentage200DInCurrency { get; set; }
    public Dictionary<string, float> PriceChangePercentage1YInCurrency { get; set; }
    public Dictionary<string, float> MarketCapChange24HInCurrency { get; set; }
    public Dictionary<string, float> MarketCapChangePercentage24HInCurrency { get; set; }
    public long TotalSupply { get; set; }
    public object MaxSupply { get; set; }
    public int CirculatingSupply { get; set; }
    public DateTime LastUpdated { get; set; }
}