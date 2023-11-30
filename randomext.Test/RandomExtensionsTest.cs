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

    [Theory]
    [InlineData(9, 6)]
    public void NextByte_ThrowsException(byte min, byte max)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _random.NextByte(min, max));
    }
    
    [Fact]
    public void NextSByte_IsRandom()
    {
        var bytes = new sbyte[Limit];
        for (var i = 0; i < Limit; i++) bytes[i] = _random.NextSByte();
        
        Assert.True(bytes.Count(x => x > 0) > FortyPercent);
    }

    [Theory]
    [InlineData(99, 66)]
    public void NextSByte_ThrowsException(byte min, byte max)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _random.NextByte(min, max));
    }
    
    [Fact]
    public void NextInt16_IsRandom()
    {
        var n = new short[Limit];
        for (var i = 0; i < Limit; i++) n[i] = _random.NextInt16();
        
        Assert.True(n.Count(x => x > 0) > FortyPercent);
    }
    
    [Theory]
    [InlineData(999, -555)]
    public void NextInt16_ThrowsException(short min, short max)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _random.NextInt16(min, max));
    }
    
    [Fact]
    public void NextUInt16_IsRandom()
    {
        var n = new ushort[Limit];
        for (var i = 0; i < Limit; i++) n[i] = _random.NextUInt16();
        
        Assert.True(n.Count(x => x > 0) > FortyPercent);
    }
    
    [Theory]
    [InlineData(999, 555)]
    public void NextUInt16_ThrowsException(ushort min, ushort max)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _random.NextUInt16(min, max));
    }
    
    [Fact]
    public void NextUInt32_IsRandom()
    {
        var n = new uint[Limit];
        for (var i = 0; i < Limit; i++) n[i] = _random.NextUInt32();
        
        Assert.True(n.Count(x => x > uint.MaxValue / 2) > FortyPercent);
    }
    
    [Theory]
    [InlineData(9999, 5555)]
    public void NextUInt32_ThrowsException(uint min, uint max)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _random.NextUInt32(min, max));
    }
    
    [Fact]
    public void NextUInt64_IsRandom()
    {
        var n = new ulong[Limit];
        for (var i = 0; i < Limit; i++) n[i] = _random.NextUInt64();
        
        Assert.True(n.Count(x => x > ulong.MaxValue / 2) > FortyPercent);
    }
    
    [Theory]
    [InlineData(10L, 255L)]
    public void NextUInt64_IsWithinRange(ulong min, ulong max)
    {
        var n = new ulong[Limit];
        for (var i = 0; i < Limit; i++) n[i] = _random.NextUInt64(min, max);

        Assert.True(n.All(x => x >= min || x <= max));
    }

    [Fact]
    public void NextChar_IsRandom()
    {
        var chars = new char[Limit];
        for (var i = 0; i < Limit; i++) chars[i] = _random.NextChar();
        
        Assert.True(chars.Count(x => x > char.MaxValue / 2) > FortyPercent);
    }
}