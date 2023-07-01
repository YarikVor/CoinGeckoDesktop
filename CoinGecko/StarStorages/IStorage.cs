using System.Collections.Generic;

namespace CoinGecko.Api;

public interface IStorage<TItem> : IEnumerable<TItem> where TItem : class
{
    void Add(TItem item);
    void Remove(TItem item);
    void Clear();
}