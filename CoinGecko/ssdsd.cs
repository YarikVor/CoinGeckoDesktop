using System.Collections.Generic;
using CoinGecko.Api.Dto.Coins;

namespace CoinGecko;

public class RootStorage
{
    public List<CoinsItemDto> SavedCoins { get; set; } = new();
}