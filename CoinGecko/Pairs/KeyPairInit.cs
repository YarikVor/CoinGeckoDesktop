namespace CoinGecko.Pairs;

public class KeyPairInit<TKey, TValue>
{
    public TKey Key { get; init; } = default!;
    public TValue Value { get; init; } = default!;
}