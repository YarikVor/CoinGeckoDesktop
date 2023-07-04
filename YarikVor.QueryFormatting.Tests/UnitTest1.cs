using Xunit.Abstractions;
using YarikVor.QueryFormatting.Abstractions;
using YarikVor.TestHelpering;

namespace YarikVor.QueryFormatting.Tests;

public class UnitTest1 : TestHelper
{
    private readonly IQueryFormatter _queryFormatter = new QueryFormatter();

    public UnitTest1(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public void ToQueryString_AnonymousObject_IsValid()
    {
        var obj = new { name = "value" };

        var actual = _queryFormatter.ToQueryString(obj);

        Write(actual);
        Assert.Equal("name=value&", actual);
    }

    [Fact]
    public void ToQueryString_NullProperties_IsSkipped()
    {
        var obj = new { id = (string?)null, name = "Yarik" };

        var actual = _queryFormatter.ToQueryString(obj);

        Write(actual);
        Assert.Equal("name=Yarik&", actual);
    }

    [Fact]
    public void ToQueryString_Primitive_IsValid()
    {
        var obj = new { id = 32, number = 1.34d };

        var actual = _queryFormatter.ToQueryString(obj);

        Write(actual);
        Assert.Equal("id=32&number=1%2c34&", actual);
    }
}