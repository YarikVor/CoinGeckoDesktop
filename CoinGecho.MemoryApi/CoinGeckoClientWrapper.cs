using CoinGecko.Api;
using CoinGecko.Api.Dto;
using CoinGecko.Api.Dto.Coins;
using Microsoft.Extensions.Caching.Memory;

namespace CoinGecho.MemoryApi;

public class CoinGeckoClientWrapper : ICoinGeckoClientWrapper
{
    public const string MarketFormat = "m:{0}";
    public const string FullInfoFormat = "fi:{0}";

    private static readonly Type CoinItemDtoArrayType = typeof(CoinItemDto[]);
    private readonly ICoinGeckoClient _geckoClient;
    private readonly IMemoryCache _memory;

    private readonly MemoryCacheEntryOptions _optionsForListCoins =
        new MemoryCacheEntryOptions().SetAbsoluteExpiration(new TimeSpan(0, 5, 0));

    public CoinGeckoClientWrapper(IMemoryCache memory, ICoinGeckoClient geckoClient)
    {
        _memory = memory;
        _geckoClient = geckoClient;
    }

    public event Action? OnError;

    public async Task<bool> PingAsync()
    {
        return await _geckoClient.PingAsync();
    }

    public async Task<CoinItemDto[]> GetListCoinsAsync()
    {
        if (_memory.TryGetValue(CoinItemDtoArrayType, out CoinItemDto[]? dtos))
            return dtos!;

        try
        {
            dtos = await _geckoClient.GetListCoinsAsync();
        }
        catch
        {
            ActiveEventOnError();
            return Array.Empty<CoinItemDto>();
        }

        _memory.Set(CoinItemDtoArrayType, dtos, _optionsForListCoins);

        return dtos;
    }

    public async Task<CoinMarketDto[]> GetCoinMarketAsync(params string[] coinIds)
    {
        var keys = coinIds
            .Select(s => string.Format(MarketFormat, s))
            .ToArray();

        var resultArray = new CoinMarketDto?[coinIds.Length];
        var listForSend = new List<string>(coinIds.Length);

        for (var index = 0; index < coinIds.Length; index++)
        {
            var id = coinIds[index];
            var key = keys[index];

            if (_memory.TryGetValue(key, out CoinMarketDto? coinMarketDto))
            {
                resultArray[index] = coinMarketDto;
                continue;
            }

            listForSend.Add(id);
        }

        if (!listForSend.Any()) return resultArray!;

        CoinMarketDto[] responce;

        try
        {
            responce = await _geckoClient.GetCoinMarketAsync(listForSend.ToArray());
        }
        catch
        {
            ActiveEventOnError();
            return resultArray!;
        }

        foreach (var dto in responce)
        {
            var index = Array.IndexOf(coinIds, dto.Id);

            var key = string.Format(MarketFormat, dto.Id);

            resultArray[index] = dto;

            _memory.Set(key, dto, _optionsForListCoins);
        }

        return resultArray!;
    }

    public async Task<CoinDto?> GetCoinAsync(string coinId)
    {
        var key = string.Format(FullInfoFormat, coinId);

        if (_memory.TryGetValue(key, out CoinDto dto))
            return dto;

        try
        {
            dto = await _geckoClient.GetCoinAsync(coinId);
        }
        catch
        {
            ActiveEventOnError();
            return null;
        }

        _memory.Set(key, dto, _optionsForListCoins);

        return dto;
    }

    private void ActiveEventOnError()
    {
        OnError?.Invoke();
    }
}