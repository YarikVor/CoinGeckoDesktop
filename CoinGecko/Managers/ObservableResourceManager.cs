using System;
using System.ComponentModel;
using System.Windows;
using CoinGecko.Pairs;
using CoinGecko.ViewModels;

namespace CoinGecko.Managers;

public abstract class ObservableResourceManager : AbstractionResourceManager, IDisposable
{
    protected readonly SettingsViewModel SettingsViewModel;

    protected ObservableResourceManager(UriPair[] items, Application application, SettingsViewModel settingsViewModel) :
        base(items, application)
    {
        SettingsViewModel = settingsViewModel;
        SettingsViewModel.PropertyChanged += SettingsViewModelOnPropertyChanged;
    }

    protected abstract string PropertyName { get; }

    public virtual void Dispose()
    {
        SettingsViewModel.PropertyChanged -= SettingsViewModelOnPropertyChanged;
    }

    private void SettingsViewModelOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName != PropertyName)
            return;

        OnPropertyChanged();
    }

    protected abstract void OnPropertyChanged();
}