using System.Collections.Generic;

namespace CoinGecko.Models;

public class CoinModel
{
    public string Name { get; set; } = null!;
    public string OriginalName { get; set; } = null!;
    public string Id { get; set; } = null!;
    public string Symbol { get; set; } = null!;
    public string Link { get; set; } = null!;
    public float CurrentPrice { get; set; }
    public Dictionary<string, float> PercentagePrice { get; set; } = null!;
    public string Description { get; set; } = null!;
}