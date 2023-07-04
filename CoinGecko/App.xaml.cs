using System;
using System.Globalization;
using System.IO;
using System.Windows;
using CoinGecho.MemoryApi;
using CoinGecko.Ex;
using CoinGecko.LocalStorage;
using CoinGecko.Managers;
using CoinGecko.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YarikVor.QueryFormatting.Services;

namespace CoinGecko;

public partial class App : Application
{
    private const string AppsettingsJson = "appsettings.json";
    private readonly IHost _host;
    private readonly IServiceProvider _provider;

    public App()
    {
        PreInit();

        _host = Host
            .CreateDefaultBuilder()
            .ConfigureServices(ConfigureServices)
            .ConfigureServices(s => s.AddSingleton<Application>(this))
            .Build();

        _provider = _host.Services;
    }

    private void PreInit()
    {
        try
        {
            using var file = File.OpenRead(AppsettingsJson);
            if (file.Length >= 10) return;
        }
        catch
        {
            // ignored
        }

        File.WriteAllText(AppsettingsJson, "{}");
    }

    private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services
            .AddWindows()
            .AddPages()
            .AddCoinGeckoClient()
            .AddQueryFormatter()
            .AddStorageManager()
            .AddMemoryCache()
            .AddCoinGeckoService()
            .AddLocalizationManager()
            .AddSettingsViewModel()
            .AddThemeManager();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        _host.Start();
        MainWindow = _provider.GetRequiredService<MainWindow>();

        InitLocalization();

        MainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host.StopAsync();
        _host.Dispose();
        base.OnExit(e);
    }

    private void InitLocalization()
    {
        var localizationManager = _provider.GetRequiredService<ILocalizationManager>();
        var themeManager = _provider.GetRequiredService<IThemeManager>();
        var managerStorage = _provider.GetRequiredService<ManagerStorage>();

        var cultureName = managerStorage.Item.SettingsModel.Culture;
        var cultureInfo = new CultureInfo(cultureName);

        localizationManager.ChangeLanguage(cultureInfo);

        var themeName = managerStorage.Item.SettingsModel.Theme;
        themeManager.ChangeTheme(themeName);
    }
}