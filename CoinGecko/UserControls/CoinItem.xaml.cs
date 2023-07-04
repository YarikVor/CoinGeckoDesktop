using System;
using System.Windows;
using System.Windows.Controls;

namespace CoinGecko.UserControls;

public partial class CoinItem : UserControl
{
    public CoinItem()
    {
        InitializeComponent();
    }

    public event Action<CoinItem>? ClickMain;
    public event Action<CoinItem>? ClickOnStar;

    private void Main_OnClick(object sender, RoutedEventArgs e)
    {
        ClickMain?.Invoke(this);
    }

    private void Star_OnClick(object sender, RoutedEventArgs e)
    {
        e.Handled = true;
        ClickOnStar?.Invoke(this);
    }
}