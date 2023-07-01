using CoinGecko.Api;

namespace CoinGecko.Tests;

public class InitTests
{
    [Fact]
    public async Task Init_IsSuccess()
    {
        var client = new CoinGeckoClient(null!);

        var actual = await client.PingAsync();

        Assert.True(actual);
    }
}