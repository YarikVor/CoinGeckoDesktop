using System.Windows.Controls;
using System.Windows.Navigation;
using CoinGecko.ViewModels;

namespace CoinGecko.Pages;

public partial class SettingsPage : Page
{
    public SettingsPage(SettingsViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }

    private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        var absoluteUri = e.Uri.AbsoluteUri;
        e.Handled = true;
        Ex.Ex.ProcessStartInfo(absoluteUri);
    }
}