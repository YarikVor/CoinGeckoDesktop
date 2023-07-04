using System;
using System.Windows;
using CoinGecko.Pairs;
using CoinGecko.ViewModels;

namespace CoinGecko.Managers;

public class ObservableThemeManager : ObservableResourceManager, IThemeManager
{
    private string _theme = null!;

    public ObservableThemeManager(UriPair[] items, Application application, SettingsViewModel settingsViewModel) : base(
        items, application, settingsViewModel)
    {
    }

    protected override string PropertyName => nameof(ViewModels.SettingsViewModel.Theme);

    public void ChangeTheme(string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (_theme == value || !UriMap.TryGetValue(value, out var uri))
            return;
        ChangeResource(uri);
        _theme = value;
    }

    protected override void OnPropertyChanged()
    {
        var culture = SettingsViewModel.Theme;
        if (culture == null)
            return;
        ChangeTheme(culture);
    }
}