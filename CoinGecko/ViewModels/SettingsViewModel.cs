using System.ComponentModel;
using System.Runtime.CompilerServices;
using CoinGecko.Models;

namespace CoinGecko.ViewModels;

public class SettingsViewModel : INotifyPropertyChanged
{
    private readonly SettingsModel _model;

    public SettingsViewModel(SettingsModel model)
    {
        _model = model;
    }

    public string? Culture
    {
        get => _model.Culture;
        set
        {
            if (_model.Culture == value || value == null)
                return;
            _model.Culture = value;
            OnPropertyChanged();
        }
    }

    public string? Theme
    {
        get => _model.Theme;
        set
        {
            if (_model.Theme == value || value == null)
                return;
            _model.Theme = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}