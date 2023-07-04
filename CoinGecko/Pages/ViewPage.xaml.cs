using System.Windows.Controls;
using System.Windows.Navigation;

namespace CoinGecko.Pages;

public partial class ViewPage : Page
{
    public ViewPage()
    {
        InitializeComponent();
    }

    private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        var absoluteUri = e.Uri.AbsoluteUri;
        e.Handled = true;
        Ex.Ex.ProcessStartInfo(absoluteUri);
    }
}