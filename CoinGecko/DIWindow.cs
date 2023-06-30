using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace CoinGecko;

public class DIWindow : Window
{
    protected IServiceProvider _services;

    public DIWindow(IServiceProvider services)
    {
        _services = services;
    }

    public TService GetRequiredService<TService>() where TService : notnull
    {
        return _services.GetRequiredService<TService>();
    }

    public TService GetRequiredService<TService>(Type type) where TService : notnull
    {
        return (TService)_services.GetRequiredService(type);
    }
}