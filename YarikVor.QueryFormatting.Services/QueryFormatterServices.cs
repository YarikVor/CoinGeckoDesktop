using Microsoft.Extensions.DependencyInjection;
using YarikVor.QueryFormatting.Abstractions;

namespace YarikVor.QueryFormatting.Services;

public static class QueryFormatterServices
{
    public static IServiceCollection AddQueryFormatter(this IServiceCollection services)
    {
        return services.AddSingleton<IQueryFormatter, QueryFormatter>();
    }
}