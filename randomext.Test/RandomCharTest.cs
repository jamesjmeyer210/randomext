namespace randomext.Test;

public sealed class RandomCharTest
{
    private readonly RandomType<char> _random;

    public RandomCharTest()
    {
        _random = new Random().As<char>();
    }

    [Theory]
    [InlineData(CharSet.Numeric)]
    [InlineData(CharSet.Alpha)]
    [InlineData(CharSet.AlphaLower)]
    [InlineData(CharSet.AlphaUpper)]
    [InlineData(CharSet.Ascii)]
    [InlineData(CharSet.Special)]
    [InlineData(CharSet.Readable)]
    [InlineData(CharSet.Invisible)]
    public void Next_ReturnsChar(CharSet set)
    {
        var c = _random.Next(set);
        Assert.IsType<char>(c);
    }

    [Theory]
    [InlineData('!', '/')]
    [InlineData(':', '@')]
    [InlineData('[', '`')]
    [InlineData('{', '~')]
    public void Next_Special_ReturnsFromMultiple_Ranges(char min, char max)
    {
        var target = _random.Next(min, max);
        var special = _random.NextChars(100, CharSet.Special);

        Assert.Contains(target, special);
    }
}