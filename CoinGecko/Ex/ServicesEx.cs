using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using CoinGecko.Api;
using CoinGecko.LocalStorage;
using CoinGecko.Managers;
using CoinGecko.Pairs;
using CoinGecko.ViewModels;
using CoinGecko.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoinGecko.Ex;

public static class ServicesEx
{
    public static IServiceCollection AddWindows(this IServiceCollection services)
    {
        return services
            .AddSingleton<MainWindow>()
            .AddTransient<ViewerWindows>();
    }

    public static IServiceCollection AddCoinGeckoClient(this IServiceCollection services)
    {
        return services.AddSingleton<ICoinGeckoClient, CoinGeckoClient>();
    }

    public static IServiceCollection AddJsonConfiguration(this IServiceCollection services,
        string fileName = "appsettings.json")
    {
        return services.AddSingleton<IConfiguration>(_ => ImplementationFactory(fileName));
    }

    private static IConfiguration ImplementationFactory(string fileName)
    {
        var configuration = new ConfigurationBuilder();
        configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(fileName, true, true)
            .AddEnvironmentVariables();
        return configuration.Build();
    }

    public static IServiceCollection AddPages(this IServiceCollection service)
    {
        var pageTypes = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(Page)));

        foreach (var pageType in pageTypes) service.AddSingleton(pageType);

        return service;
    }

    public static IServiceCollection AddStorageManager(this IServiceCollection service)
    {
        service.AddSingleton<ManagerStorage>(_ => new ManagerStorage("appsettings.json"));
        return service;
    }

    public static IServiceCollection AddLocalizationManager(this IServiceCollection service)
    {
        return service.AddSingleton(LocalizationManagerFactory);
    }

    private static ILocalizationManager LocalizationManagerFactory(IServiceProvider services)
    {
        var application = services.GetRequiredService<Application>();
        var viewModel = services.GetRequiredService<SettingsViewModel>();

        var mergedDictionaries = application
            .Resources
            .MergedDictionaries;

        var languageItems = (UriPair[])mergedDictionaries
            .SelectMany(rd => rd.Cast<DictionaryEntry>())
            .First(de => de.Key is "Languages").Value!;

        return new ObservableLocalizationManager(languageItems, application, viewModel);
    }

    public static IServiceCollection AddSettingsViewModel(this IServiceCollection services)
    {
        return services.AddSingleton(SettingsViewModelFactory);
    }

    private static SettingsViewModel SettingsViewModelFactory(IServiceProvider provider)
    {
        var managerStorage = provider.GetRequiredService<ManagerStorage>();
        return new SettingsViewModel(managerStorage.Item.SettingsModel);
    }

    public static IServiceCollection AddThemeManager(this IServiceCollection service)
    {
        return service.AddSingleton(ThemeManagerFactory);
    }

    private static IThemeManager ThemeManagerFactory(IServiceProvider provider)
    {
        var application = provider.GetRequiredService<Application>();
        var viewModel = provider.GetRequiredService<SettingsViewModel>();

        var mergedDictionaries = application
            .Resources
            .MergedDictionaries;

        var languageItems = (UriPair[])mergedDictionaries
            .SelectMany(rd => rd.Cast<DictionaryEntry>())
            .First(de => de.Key is "Themes").Value!;

        return new ObservableThemeManager(languageItems, application, viewModel);
    }
}