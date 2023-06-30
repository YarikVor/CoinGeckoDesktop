using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoinGecko;

public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host
            .CreateDefaultBuilder()
            .ConfigureServices(ConfigureServices)
            .Build();
    }

    private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services
            .AddWindows()
            .AddJsonConfiguration()
            .AddPages()
            .AddCoinGeckoClient();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _host.Start();

        var services = _host.Services;

        MainWindow = services.GetRequiredService<MainWindow>();

        var configuration = services.GetRequiredService<IConfiguration>();

        MainWindow.Show();

        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _host.StopAsync();
        _host.Dispose();

        base.OnExit(e);
    }
}