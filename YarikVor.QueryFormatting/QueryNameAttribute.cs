namespace CoinGecko;

[AttributeUsage(AttributeTargets.Property)]
public class QueryNameAttribute : Attribute
{
    public readonly string Name;

    public QueryNameAttribute(string name)
    {
        Name = name;
    }
}