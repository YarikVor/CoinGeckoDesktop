using System.Windows.Controls;
using CoinGecko.UserControls;

namespace CoinGecko.Pages;

public partial class SavedPage : Page
{
    private readonly ManagerStorage<RootStorage> _storage;

    public SavedPage(ManagerStorage<RootStorage> storage)
    {
        _storage = storage;
        InitializeComponent();
    }

    public override void BeginInit()
    {
        var list = _storage.Item.SavedCoins;

        foreach (var elem in list)
        {
            var ui = new CoinItem
            {
                Nick = elem.Name
            };
            ui.DataContext
        }

        StackList.Children.Add()

        base.BeginInit();
    }
}