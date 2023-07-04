using CoinGecko.Models;

namespace CoinGecko.LocalStorage;

public class RootStorage
{
    public SettingsModel SettingsModel { get; set; } = new()
    {
        Culture = "en-US",
        Theme = "Light"
    };
}