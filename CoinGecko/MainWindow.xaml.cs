using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CoinGecko.Api;
using CoinGecko.Api.Dto.Coins;
using CoinGecko.Panels;
using CoinGecko.UserControls;

namespace CoinGecko;

public partial class MainWindow : DIWindow
{
    private readonly CoinGeckoClient _geckoClient;

    private ObservableCollection<CoinsItemDto> _collection = new();


    public MainWindow(CoinGeckoClient geckoClient, IServiceProvider services) : base(services)
    {
        _geckoClient = geckoClient;

        InitializeComponent();

        //LoadData();
    }

    public async Task LoadData()
    {
        var list = await _geckoClient.GetListCoins();

        var collection = new ObservableCollection<CoinItem>(list.Take(10).Select(c => new CoinItem
        {
            Id = c.Id,
            Nick = c.Name,
            Symbol = c.Symbol
        }));

        //ItemsControl.ItemsSource = collection;
    }

    private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (NavList.SelectedIndex < 0)
            return;

        var selected = (IconMenu)NavList.SelectedItem;
        //var pageUri = selected.PageUri;

        var type = selected.PageType;

        if (type == null)
            return;

        var page = GetRequiredService<Page>(type);

        //NavFrame.Navigate(pageUri, );
        NavFrame.Navigate(page);
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        LoadData();
    }
}