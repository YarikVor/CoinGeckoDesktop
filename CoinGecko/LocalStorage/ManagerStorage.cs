using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoinGecko.LocalStorage;

public class ManagerStorage : IDisposable
{
    private readonly string _fileName;

    private readonly Task _timer;

    public ManagerStorage(string fileName)
    {
        _fileName = fileName;

        Init();

        _timer = TimerForUpdate();
    }

    public RootStorage? Item { get; private set; } 

    public async void Dispose()
    {
        await SaveAsync();
        _timer.Dispose();
    }

    private async Task TimerForUpdate()
    {
        while (true)
        {
            await Task.Delay(10_000);
            await SaveAsync();
        }
    }

    public async Task SaveAsync()
    {
        await using var stream = new FileStream(_fileName, FileMode.Create);
        await JsonSerializer.SerializeAsync(stream, Item);
    }

    private void Init()
    {
        FileStream? file = null!;
        try
        {
            file = File.Open(_fileName, FileMode.Open);
        }
        catch
        {
            Item = new RootStorage();
            file?.Dispose();
            return;
        }

        if (file.Length <= 5)
        {
            Item = new RootStorage();
            return;
        }

        Item = JsonSerializer.Deserialize<RootStorage>(file)!;
    }
}