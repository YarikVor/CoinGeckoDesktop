using CoinGecko.Api;
using Xunit.Abstractions;
using YarikVor.TestHelpering;

namespace CoinGecko.Tests;

public class ListCoinsTests : TestHelper
{
    public ListCoinsTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async Task GetListCoins_IsSuccessful()
    {
        var client = new CoinGeckoClient(null!);

        var result = await client.GetListCoinsAsync();

        Assert.NotNull(result);

        var element = result[Random.Shared.Next(0, 5)];

        Assert.NotNull(element);

        Assert.NotNull(element.Id);
        Assert.NotNull(element.Name);
        Assert.NotNull(element.Symbol);

        WriteAsJson(element);
    }
}