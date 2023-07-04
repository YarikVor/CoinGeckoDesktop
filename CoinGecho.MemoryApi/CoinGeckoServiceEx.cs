using Microsoft.Extensions.DependencyInjection;

namespace CoinGecho.MemoryApi;

public static class CoinGeckoServiceEx
{
    public static IServiceCollection AddCoinGeckoService(this IServiceCollection services)
    {
        return services.AddSingleton<ICoinGeckoClientWrapper, CoinGeckoClientWrapper>();
    }
}