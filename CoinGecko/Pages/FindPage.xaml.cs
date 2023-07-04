using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using CoinGecho.MemoryApi;
using CoinGecko.Api.Dto.Coins;
using CoinGecko.Models;
using CoinGecko.UserControls;
using CoinGecko.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace CoinGecko.Pages;

public partial class FindPage : Page
{
    private readonly ICoinGeckoClientWrapper _geckoClient;
    private readonly IServiceProvider _serviceProvider;

    public FindPage(ICoinGeckoClientWrapper geckoClient, IServiceProvider serviceProvider)
    {
        _geckoClient = geckoClient;
        _serviceProvider = serviceProvider;
        DataContext = this;

        InitializeComponent();
    }

    public ObservableCollection<CoinItemDto> CoinItems { get; } = new();

    private async Task TimerInputOnElapsed()
    {
        var list = await _geckoClient.GetListCoinsAsync();

        var searchText = Search.Text;

        var filtration = string.IsNullOrEmpty(searchText)
            ? list
            : list.Where(c => c.Name.StartsWith(searchText) || c.Id.StartsWith(searchText));

        CoinItems.Clear();

        foreach (var dto in filtration.Take(15)) CoinItems.Add(dto);
    }

    private async void CoinInfoOnClickMain(CoinItem obj)
    {
        var dto = (CoinItemDto)obj.DataContext;

        var window = _serviceProvider.GetRequiredService<ViewerWindows>();

        var coinsInfo = await _geckoClient.GetCoinAsync(dto.Id);

        window.Show();

        window.DataContext = WindowDataContext(coinsInfo);
    }

    private static CoinModel WindowDataContext(CoinDto coinInfo)
    {
        var marketData = coinInfo.MarketData;

        return new CoinModel
        {
            Name = coinInfo.Name,
            OriginalName = coinInfo.Name,
            Id = coinInfo.Id,
            Symbol = coinInfo.Symbol,
            Link = coinInfo.Links.Homepage.Where(s => !string.IsNullOrEmpty(s)).FirstOrDefault(""),
            CurrentPrice = coinInfo.MarketData.CurrentPrice.First().Value,
            PercentagePrice = new Dictionary<string, float>
            {
                ["1d"] = marketData.PriceChangePercentage24H ?? 0,
                ["7d"] = marketData.PriceChangePercentage7d,
                ["14d"] = marketData.PriceChangePercentage14d,
                ["30d"] = marketData.PriceChangePercentage30d,
                ["60d"] = marketData.PriceChangePercentage60d
            },
            Description = coinInfo.Description.First().Value
        };
    }


    private async void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        await TimerInputOnElapsed();
    }
}