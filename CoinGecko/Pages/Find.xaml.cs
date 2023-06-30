using System.Windows.Controls;
using CoinGecko.Api;

namespace CoinGecko.Pages;

public partial class Find : Page
{
    private readonly CoinGeckoClient _geckoClient;
    
    public Find(CoinGeckoClient geckoClient)
    {
        _geckoClient = geckoClient;
        InitializeComponent();
    }
}