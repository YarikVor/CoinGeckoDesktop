namespace CoinGecko.Api.Dto.Coins;

public class CoinItemWithPlatformsDto : CoinItemDto
{
    public Dictionary<string, string> Platforms = null!;
}