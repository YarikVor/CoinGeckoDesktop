using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using CoinGecko.Api;

namespace CoinGecko.Pages;

public partial class ConvertorPage : Page
{
    private readonly CoinGeckoClient _geckoClient;

    public ConvertorPage(CoinGeckoClient geckoClient)
    {
        InitializeComponent();

        _geckoClient = geckoClient;

        GetData();
    }

    private async Task GetData()
    {
        var collection = await _geckoClient.GetListCoinsAsync();

        var items = collection.Select(e => e.Id).ToArray();

        BeforeList.ItemsSource = items;
        AfterList.ItemsSource = items;
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

        var beforeCoin = BeforeList.SelectedItem as string;
        var afterCoin = AfterList.SelectedItem as string;
        var coinsTask = await _geckoClient.GetCoinMarketAsync(beforeCoin, afterCoin);

        if (coinsTask.Length != 2)
        {
            ChangeOutput("Error");
            return;
        }

        var beforeCoinUsd = coinsTask[0].CurrentPrice;
        var afterCoinUsd = coinsTask[1].CurrentPrice;

        var calc = result * afterCoinUsd / beforeCoinUsd;

        ChangeOutput(calc.ToString());
    }

    private void ChangeOutput(string text)
    {
        Output.Text = text;
    }
}