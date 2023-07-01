using System.Text.Json;
using CoinGecko.Api.Dto.Coins;
using CoinGecko.Api.Requests;

namespace CoinGecko.Api;

public class CoinGeckoClient
{
    public const string BaseUri = "https://api.coingecko.com/api/v3/";

    private const string PingUrl = "ping";

    private const string ListCoinsUrl = "coins/list?include_platform={0}";
    private const string CoinMarketUrl = "coins/markets";

    private readonly HttpClient _client;
    private readonly IQueryFormatter _formatter;

    public CoinGeckoClient(IQueryFormatter formatter)
    {
        _formatter = formatter;
        _client = new HttpClient();

        _client.BaseAddress = new Uri(BaseUri);
        _client.DefaultRequestHeaders.Add("user-agent", "other");
    }

    public async Task<bool> PingAsync()
    {
        var responseMessage = await _client.GetAsync(PingUrl);
        return responseMessage.IsSuccessStatusCode;
    }

    public async Task<CoinsItemDto[]> GetListCoinsAsync()
    {
        var stream = await GetListCoinsAsync(false);

        var result = await JsonSerializer.DeserializeAsync<CoinsItemDto[]>(
            stream,
            CoinGeckoClientUtility.JsonSerializerOptions
        );

        return result!;
    }

    private Task<Stream> GetListCoinsAsync(bool includePlatform)
    {
        var requestUri = string.Format(ListCoinsUrl, includePlatform.ToLowerString());

        return _client.GetStreamAsync(requestUri);
    }

    public async Task<CoinMarketDto[]> GetCoinMarketAsync(params string[] coinIds)
    {
        var request = CreateCoinMarketRequest(coinIds);
        var queryString = _formatter.ToQueryString(request);
        var requestUri = $"{CoinMarketUrl}?{queryString}";

        var res = await _client.GetStreamAsync(requestUri);
        var result = JsonSerializer.Deserialize<CoinMarketDto[]>(res);

        return result;
    }

    private CoinMarketRequest CreateCoinMarketRequest(IEnumerable<string> coinIds)
    {
        return new CoinMarketRequest
        {
            VsCurrency = "eur",
            Ids = string.Join(',', coinIds)
        };
    }
}