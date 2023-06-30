using CoinGecko.Api;

namespace CoinGecko.Tests;

public class InitTests
{
    [Fact]
    public async Task Init_IsSuccess()
    {
        var client = new CoinGeckoClient();

        var expected = await client.PingAsync();

        Assert.True(expected);
    }
}