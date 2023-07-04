using System.Globalization;

namespace CoinGecko.Managers;

public interface ILocalizationManager
{
    void ChangeLanguage(CultureInfo value);
}