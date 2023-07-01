using System.Collections;
using System.Collections.Generic;
using CoinGecko.Api.Dto.Coins;

namespace CoinGecko.Api;

public class StarStorage : IStarStorage
{
    private readonly List<CoinsItemDto> _list = new();

    public IEnumerator<CoinsItemDto> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(CoinsItemDto item)
    {
        _list.Add(item);
    }

    public void Remove(CoinsItemDto item)
    {
        _list.Remove(item);
    }

    public void Clear()
    {
        _list.Clear();
    }

    public void Dispose()
    {
    }
}