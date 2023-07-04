using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace CoinGecko.Windows;

public class DiWindow : Window
{
    protected readonly IServiceProvider Services;

    public DiWindow(IServiceProvider services)
    {
        Services = services;
    }

    public TService GetRequiredService<TService>() where TService : notnull
    {
        return Services.GetRequiredService<TService>();
    }

    public TService GetRequiredService<TService>(Type type) where TService : notnull
    {
        return (TService)Services.GetRequiredService(type);
    }
}