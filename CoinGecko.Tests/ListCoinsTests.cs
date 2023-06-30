using System.Text.Json;
using CoinGecko.Api;
using Xunit.Abstractions;

namespace CoinGecko.Tests;

public class ListCoinsTests
{
    private readonly ITestOutputHelper _output;

    public ListCoinsTests(ITestOutputHelper output)
    {
        _output = output;
    }


    [Fact]
    public async Task GetListCoins_IsSuccessful()
    {
        var client = new CoinGeckoClient();

        var result = await client.GetListCoins();
        
        Assert.NotNull(result);

        var element = result[Random.Shared.Next(0, 5)];
        
        Assert.NotNull(element);
        
        Assert.NotNull(element.Id);
        Assert.NotNull(element.Name);
        Assert.NotNull(element.Symbol);
        
        WriteAsJson(element);
        
    }



    public void Write(string str)
    {
        _output.WriteLine(str);
    }

    public void WriteAsJson(object obj)
    {
        var json = JsonSerializer.Serialize(obj);
        
        _output.WriteLine(json);
    }
}