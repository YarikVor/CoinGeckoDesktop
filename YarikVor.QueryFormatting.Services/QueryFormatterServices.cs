using CoinGecko;
using Microsoft.Extensions.DependencyInjection;

namespace YarikVor.QueryFormatting.Services;

public static class QueryFormatterServices
{
    public static IServiceCollection AddQueryFormatter(this IServiceCollection services)
    {
        return services.AddSingleton<IQueryFormatter, QueryFormatter>();
    }
}