namespace randomext;

public readonly struct RandomType<T>
{
    public readonly Random Inner;
    
    internal RandomType(Random inner)
    {
        Inner = inner;
    }

    public RandomType<TOther> As<TOther>() => new(Inner);

    public static implicit operator Random(RandomType<T> randomType) => randomType.Inner;
}

public static class RandomTypeExtensions
{
    public static bool Next(this RandomType<bool> self) => self.Inner.NextBool();

    public static byte Next(this RandomType<byte> self, byte min = byte.MinValue, byte max = byte.MaxValue) => 
        self.Inner.NextByte(min, max);
    
    public static sbyte Next(this RandomType<sbyte> self, sbyte min = sbyte.MinValue, sbyte max = sbyte.MaxValue) => 
        self.Inner.NextSByte(min, max);
    
    public static short Next(this RandomType<short> self, short min = short.MinValue, short max = short.MaxValue) => 
        self.Inner.NextInt16(min, max);
    
    public static ushort Next(this RandomType<ushort> self, ushort min = ushort.MinValue, ushort max = ushort.MaxValue) => 
        self.Inner.NextUInt16(min, max);
    
    public static int Next(this RandomType<int> self, int min = int.MinValue, int max = int.MaxValue) => 
        self.Inner.NextInt32(min, max);
    
    public static uint Next(this RandomType<uint> self, uint min = uint.MinValue, uint max = uint.MaxValue) => 
        self.Inner.NextUInt32(min, max);

    public static long Next(this RandomType<long> self, long min = long.MinValue, long max = long.MaxValue) =>
        self.Inner.NextInt64(min, max);
    
    public static ulong Next(this RandomType<ulong> self, ulong min = ulong.MinValue, ulong max = ulong.MaxValue) =>
        self.Inner.NextUInt64(min, max);
}