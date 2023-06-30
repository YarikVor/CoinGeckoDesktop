using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using CoinGecko.Api;
using CoinGecko.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoinGecko;

public static class ServicesEx
{
    public static IServiceCollection AddWindows(this IServiceCollection services)
    {
        return services.AddSingleton<MainWindow>();
    }

    public static IServiceCollection AddCoinGeckoClient(this IServiceCollection services)
    {
        return services.AddSingleton<CoinGeckoClient>();
    }

    public static IServiceCollection AddJsonConfiguration(this IServiceCollection services,
        string fileName = "appsettings.json")
    {
        return services.AddSingleton<IConfiguration>(s => ImplementationFactory(s, fileName));
    }

    private static IConfiguration ImplementationFactory(IServiceProvider service, string fileName)
    {
        var configuration = new ConfigurationBuilder();
        configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(fileName, optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
        return configuration.Build();
    }

    public static IServiceCollection AddPages(this IServiceCollection service)
    {
        var pageTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(Page)));

        foreach (var pageType in pageTypes)
        {
            service.AddSingleton(pageType);
        }

        return service;
    }
}