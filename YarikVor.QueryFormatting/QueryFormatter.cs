using System.Reflection;
using System.Text;
using System.Web;
using YarikVor.QueryFormatting.Abstractions;

namespace YarikVor.QueryFormatting;

public class QueryFormatter : IQueryFormatter
{
    private readonly Dictionary<Type, Func<object, string>> _convertorsMap = new()
    {
        { typeof(bool), obj => (bool)obj ? "true" : "false" }
    };

    private readonly Dictionary<Type, PropertyInfo[]> _propertyInfosMap = new();

    public string ToQueryString<TObject>(TObject obj) where TObject : notnull
    {
        return ToQueryString(obj, typeof(TObject));
    }

    public string ToQueryString(object obj)
    {
        return ToQueryString(obj, obj.GetType());
    }

    public string ToQueryString(object obj, Type type)
    {
        var propertyInfos = GetPropertyInfos(type);

        var objInfo = propertyInfos
            .Select(p => (
                    name: p.GetCustomAttribute<QueryPropertyNameAttribute>()?.Name ?? p.Name,
                    value: p.GetValue(obj)
                )
            )
            .Where(t => t.value != null);

        var queryString = ToQueryString(objInfo!);

        return queryString;
    }

    private string ToQueryString(IEnumerable<(string name, object value)> tuple)
    {
        var sb = new StringBuilder();

        foreach (var elem in tuple)
        {
            var value = ConvertValue(elem.value);
            sb
                .Append(elem.name)
                .Append('=')
                .Append(HttpUtility.UrlEncode(value))
                .Append('&');
        }

        return sb.ToString();
    }

    private string ConvertValue(object obj)
    {
        return ConvertValue(obj, obj.GetType());
    }

    private string ConvertValue(object obj, Type type)
    {
        return _convertorsMap.TryGetValue(type, out var func)
            ? func(obj)
            : obj.ToString()!;
    }

    private PropertyInfo[] GetPropertyInfos(Type type)
    {
        if (_propertyInfosMap.TryGetValue(type, out var result))
            return result;

        result = type.GetProperties().Where(p => p.CanRead).ToArray();

        _propertyInfosMap[type] = result;

        return result;
    }
}