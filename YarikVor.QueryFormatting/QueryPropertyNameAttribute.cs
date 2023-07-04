namespace YarikVor.QueryFormatting;

[AttributeUsage(AttributeTargets.Property)]
public class QueryPropertyNameAttribute : Attribute
{
    public readonly string Name;

    public QueryPropertyNameAttribute(string name)
    {
        Name = name;
    }
}