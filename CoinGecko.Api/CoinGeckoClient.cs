using System.Text.Json;
using CoinGecko.Api.Dto.Coins;

namespace CoinGecko.Api;

public class CoinGeckoClient
{
    public const string BaseUri = "https://api.coingecko.com/api/v3/";

    private const string PingUrl = $"ping";

    private const string ListCoinsUrl = "coins/list?include_platform={0}";

    private readonly HttpClient _client;

    public CoinGeckoClient()
    {
        _client = new HttpClient();

        _client.BaseAddress = new Uri(BaseUri);
    }

    public async Task<bool> PingAsync()
    {
        var responseMessage = await _client.GetAsync(PingUrl);
        return responseMessage.IsSuccessStatusCode;
    }

    public async Task<CoinsItemDto[]> GetListCoins()
    {
        var stream = await GetListCoins(false);

        var result = await JsonSerializer.DeserializeAsync<CoinsItemDto[]>(
            stream,
            CoinGeckoClientUtility.JsonSerializerOptions
        );

        return result!;
    }

    private Task<Stream> GetListCoins(bool includePlatform)
    {
        var requestUri = string.Format(ListCoinsUrl, includePlatform.ToLowerString());

        return _client.GetStreamAsync(requestUri);
    }

}