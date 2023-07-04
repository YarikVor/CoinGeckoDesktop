using System.Diagnostics;

namespace CoinGecko.Ex;

public static class Ex
{
    public static void ProcessStartInfo(string absoluteUri)
    {
        Process.Start(new ProcessStartInfo(absoluteUri) { UseShellExecute = true });
    }
}