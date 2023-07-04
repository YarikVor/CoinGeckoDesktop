using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CoinGecho.MemoryApi;
using CoinGecko.Api.Dto.Coins;

namespace CoinGecko.Pages;

public partial class ConvertorPage : Page
{
    public static readonly DependencyProperty CoinItemDtosProperty = DependencyProperty.Register(
        nameof(CoinItemDtos),
        typeof(CoinItemDto[]),
        typeof(ConvertorPage),
        new PropertyMetadata(Array.Empty<CoinItemDto>())
    );

    private readonly ICoinGeckoClientWrapper _geckoClient;

    public ConvertorPage(ICoinGeckoClientWrapper geckoClient)
    {
        InitializeComponent();

        _geckoClient = geckoClient;

        GetData();
    }

    public CoinItemDto[] CoinItemDtos
    {
        get => (CoinItemDto[])GetValue(CoinItemDtosProperty);
        set => SetValue(CoinItemDtosProperty, value);
    }

    private async Task GetData()
    {
        CoinItemDtos = await _geckoClient.GetListCoinsAsync();
    }

    private async void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var text = Input.Text;

        if (!double.TryParse(text, out var result))
        {
            ChangeOutput("It's not number");
            return;
        }

        if (BeforeList.SelectedIndex == -1 || AfterList.SelectedIndex == -1)
        {
            ChangeOutput("Please select coins");
            return;
        }

        var beforeCoin = (string)BeforeList.SelectedValue;
        var afterCoin = (string)AfterList.SelectedValue;

        var coinsTask = await _geckoClient.GetCoinMarketAsync(beforeCoin, afterCoin);

        if (coinsTask.Length != 2 || coinsTask.Any(el => el == null))
        {
            ChangeOutput("Error");
            return;
        }

        var beforeCoinUsd = coinsTask[0].CurrentPrice;
        var afterCoinUsd = coinsTask[1].CurrentPrice;

        var calc = result * afterCoinUsd / beforeCoinUsd;

        ChangeOutput(calc.ToString(CultureInfo.InvariantCulture));
    }

    private void ChangeOutput(string text)
    {
        Output.Text = text;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        (BeforeList.SelectedIndex, AfterList.SelectedIndex)
            = (AfterList.SelectedIndex, BeforeList.SelectedIndex);

        TextBoxBase_OnTextChanged(null, null);
    }
}