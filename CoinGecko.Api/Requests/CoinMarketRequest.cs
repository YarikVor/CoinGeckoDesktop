namespace CoinGecko.Api.Requests;

public class CoinMarketRequest
{
    [QueryName("vs_currency")]
    public string VsCurrency { get; set; } = null!;

    [QueryName("ids")]
    public string? Ids { get; set; }

    [QueryName("category")]
    public string? Category { get; set; }

    [QueryName("order")]
    public string? Order { get; set; }

    [QueryName("per_page")]
    public int PerPage { get; set; } = 100;

    [QueryName("page")]
    public int Page { get; set; } = 1;

    [QueryName("sparkline")]
    public bool Sparkline { get; set; } = false;

    [QueryName("price_change_percentage")]
    public string? PriceChangePercentage { get; set; }

    [QueryName("locale")]
    public string? Locale { get; set; }

    [QueryName("precision")]
    public string? Precision { get; set; }
}