using System.Windows.Controls;

namespace CoinGecko.UserControls;

public partial class CoinItem : UserControl
{
    public CoinItem()
    {
        InitializeComponent();
        DataContext = this;
    }

    public string Nick { get; set; }
    public string Id { get; set; }
    public string Symbol { get; set; }
}