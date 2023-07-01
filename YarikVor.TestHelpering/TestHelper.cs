using System.Text.Json;
using Xunit.Abstractions;

namespace YarikVor.TestHelpering;

public abstract class TestHelper
{
    private readonly ITestOutputHelper _output;

    protected TestHelper(ITestOutputHelper output)
    {
        _output = output;
    }

    public void Write(string str)
    {
        _output.WriteLine(str);
    }

    public void WriteAsJson(object obj)
    {
        var json = JsonSerializer.Serialize(obj);

        _output.WriteLine(json);
    }
}