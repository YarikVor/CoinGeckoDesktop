using YarikVor.QueryFormatting;

namespace CoinGecko.Api.Requests;

public class CoinMarketRequest
{
    [QueryPropertyName("vs_currency")]
    public string VsCurrency { get; set; } = null!;

    [QueryPropertyName("ids")]
    public string? Ids { get; set; }

    [QueryPropertyName("category")]
    public string? Category { get; set; }

    [QueryPropertyName("order")]
    public string? Order { get; set; }

    [QueryPropertyName("per_page")]
    public int PerPage { get; set; } = 100;

    [QueryPropertyName("page")]
    public int Page { get; set; } = 1;

    [QueryPropertyName("sparkline")]
    public bool Sparkline { get; set; } = false;

    [QueryPropertyName("price_change_percentage")]
    public string? PriceChangePercentage { get; set; }

    [QueryPropertyName("locale")]
    public string? Locale { get; set; }

    [QueryPropertyName("precision")]
    public string? Precision { get; set; }
}