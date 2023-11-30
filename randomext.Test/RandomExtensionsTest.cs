namespace randomext.Test;

public class RandomExtensionsTest
{
    private const int Limit = 10_000;
    private const int FortyPercent = 4_000;
    private readonly Random _random;

    public RandomExtensionsTest()
    {
        _random = new Random();
    }

    [Fact]
    public void NextBool_IsRandom()
    {
        var booleans = new bool[Limit];
        for (var i = 0; i < Limit; i++) booleans[i] = _random.NextBool();
        
        Assert.True(booleans.Count(x => x) > FortyPercent);
    }

    [Fact]
    public void NextByte_IsRandom()
    {
        var bytes = new byte[Limit];
        for (var i = 0; i < Limit; i++) bytes[i] = _random.NextByte();
        
        Assert.True(bytes.Count(x => x < byte.MaxValue/2) > FortyPercent);
    }
    
    [Fact]
    public void NextSByte_IsRandom()
    {
        var bytes = new sbyte[Limit];
        for (var i = 0; i < Limit; i++) bytes[i] = _random.NextSByte();
        
        Assert.True(bytes.Count(x => x > 0) > FortyPercent);
    }

    [Fact]
    public void NextShort_IsRandom()
    {
        var n = new short[Limit];
        for (var i = 0; i < Limit; i++) n[i] = _random.NextInt16();
        
        Assert.True(n.Count(x => x > 0) > FortyPercent);
    }
    
    [Fact]
    public void NextUShort_IsRandom()
    {
        var n = new ushort[Limit];
        for (var i = 0; i < Limit; i++) n[i] = _random.NextUInt16();
        
        Assert.True(n.Count(x => x > 0) > FortyPercent);
    }
    
    [Fact]
    public void NextUInt32_IsRandom()
    {
        var n = new uint[Limit];
        for (var i = 0; i < Limit; i++) n[i] = _random.NextUInt32();
        
        Assert.True(n.Count(x => x > uint.MaxValue / 2) > FortyPercent);
    }
    
    [Fact]
    public void NextChar_IsRandom()
    {
        var chars = new char[Limit];
        for (var i = 0; i < Limit; i++) chars[i] = _random.NextChar();
        
        Assert.True(chars.Count(x => x > char.MaxValue / 2) > FortyPercent);
    }
}