using CoinGecko.Api;

namespace CoinGecho.MemoryApi;

public interface ICoinGeckoClientWrapper : ICoinGeckoClient
{
    public event Action OnError;
}