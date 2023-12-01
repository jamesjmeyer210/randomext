namespace randomext.Test;

public sealed class RandomCharTest
{
    private readonly RandomType<char> _random;

    public RandomCharTest()
    {
        _random = new Random().As<char>();
    }

    [Theory]
    [InlineData(CharGroup.Numeric)]
    [InlineData(CharGroup.Alpha)]
    [InlineData(CharGroup.AlphaLower)]
    [InlineData(CharGroup.AlphaUpper)]
    [InlineData(CharGroup.Ascii)]
    [InlineData(CharGroup.Special)]
    [InlineData(CharGroup.Readable)]
    [InlineData(CharGroup.Invisible)]
    public void Next_ReturnsChar(CharGroup group)
    {
        var c = _random.Next(group);
        Assert.IsType<char>(c);
    }
}