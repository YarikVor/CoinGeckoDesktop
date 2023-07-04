using CoinGecko.Api.Dto;
using CoinGecko.Api.Dto.Coins;

namespace CoinGecko.Api;

public interface ICoinGeckoClient
{
    Task<bool> PingAsync();
    Task<CoinItemDto[]> GetListCoinsAsync();
    Task<CoinMarketDto[]> GetCoinMarketAsync(params string[] coinIds);
    Task<CoinDto> GetCoinAsync(string coinId);
}