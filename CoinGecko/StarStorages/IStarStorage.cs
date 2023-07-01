using System;
using CoinGecko.Api.Dto.Coins;

namespace CoinGecko.Api;

public interface IStarStorage : IStorage<CoinsItemDto>, IDisposable
{
}