using System.Text.RegularExpressions;
using CoinGecko.Api;
using Xunit.Abstractions;
using YarikVor.TestHelpering;

namespace CoinGecko.Tests;

public class CoinInfo : TestHelper
{
    public CoinInfo(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async Task G()
    {
        var client = new CoinGeckoClient(null!);
        var result = await client.GetCoinAsync("01coin");

        WriteAsJson(result);
    }

    [Fact]
    public async Task ListError()
    {
        var client = new CoinGeckoClient(null!);

        var list = await client.GetListCoinsAsync();

        var listError = new List<string>(10000);

        var regex = new Regex(@"\$\.([\w\.]+)");

        foreach (var id in list.Select(e => e.Id))
            try
            {
                await client.GetCoinAsync(id);
            }
            catch (Exception e)
            {
                var match = regex.Match(e.Message);
                if (match.Groups.Count == 0)
                    continue;

                var propertyText = match.Groups[1].Value;

                listError.Add(propertyText);
            }

        Write(string.Join('\n', listError));
    }
}