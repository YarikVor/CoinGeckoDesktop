using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using CoinGecko.Pairs;
using CoinGecko.ViewModels;

namespace CoinGecko.Managers;

public class ObservableLocalizationManager : ObservableResourceManager, ILocalizationManager
{
    private readonly Uri _defaultUri;

    public ObservableLocalizationManager(UriPair[] items, Application application, SettingsViewModel settingsViewModel)
        : base(items, application, settingsViewModel)
    {
        _defaultUri = items[0].Value;
    }

    protected override string PropertyName => nameof(ViewModels.SettingsViewModel.Culture);

    public CultureInfo CurrentUiCulture
    {
        get => Thread.CurrentThread.CurrentUICulture;
        set => Thread.CurrentThread.CurrentUICulture = value;
    }

    public void ChangeLanguage(CultureInfo value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == CurrentUiCulture)
            return;

        CurrentUiCulture = value;

        var resourceUri = UriMap.TryGetValue(value.Name, out var uri)
            ? uri
            : _defaultUri;

        ChangeResource(resourceUri);
    }

    protected override void OnPropertyChanged()
    {
        var culture = SettingsViewModel.Culture;

        if (culture == null)
            return;

        var cultureInfo = new CultureInfo(culture);
        ChangeLanguage(cultureInfo);
    }
}