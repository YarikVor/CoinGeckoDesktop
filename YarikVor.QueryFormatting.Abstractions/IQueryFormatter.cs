namespace CoinGecko;

public interface IQueryFormatter
{
    string ToQueryString<TObject>(TObject obj) where TObject : notnull;
    string ToQueryString(object obj, Type type);
    string ToQueryString(object obj);
}