using CoinGecko.Api;
using Xunit.Abstractions;
using YarikVor.QueryFormatting;
using YarikVor.TestHelpering;

namespace CoinGecko.Tests;

public class CoinMarkets : TestHelper
{
    public CoinMarkets(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async Task GetCoinMarkets_IsSuccessful()
    {
        var client = new CoinGeckoClient(new QueryFormatter());

        var firstCoin = (await client.GetListCoinsAsync())[0];

        var result = await client.GetCoinMarketAsync(firstCoin.Id);
        WriteAsJson(result);
    }
}