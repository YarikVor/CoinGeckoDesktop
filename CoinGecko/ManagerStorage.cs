using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoinGecko;

public class ManagerStorage<TItem> : IDisposable where TItem : class, new()
{
    public string fileName;
    public TItem Item;

    public Task Timer;


    public ManagerStorage(string fileName)
    {
        this.fileName = fileName;

        LoadAsync();

        Timer = TimerForUpdate();
    }

    public async void Dispose()
    {
        await SaveAsync();
        Timer.Dispose();
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
        await using var stream = new FileStream(fileName, FileMode.Create);
        await JsonSerializer.SerializeAsync(stream, Item);
    }

    public async void LoadAsync()
    {
        if (!File.Exists(fileName))
        {
            Item = new TItem();
            return;
        }

        await using var stream = new FileStream(fileName, FileMode.OpenOrCreate);

        Item = await JsonSerializer.DeserializeAsync<TItem>(stream) ?? new TItem();
    }
}