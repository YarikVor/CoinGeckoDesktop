using System;
using System.Collections;
using System.Collections.Generic;
using CoinGecko.Api.Dto.Coins;

namespace CoinGecko;

public class SavedCoins : ICollection<CoinsItemDto>
{
    public IEnumerator<CoinsItemDto> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(CoinsItemDto item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(CoinsItemDto item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(CoinsItemDto[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(CoinsItemDto item)
    {
        throw new NotImplementedException();
    }

    public int Count { get; }
    public bool IsReadOnly { get; }
}