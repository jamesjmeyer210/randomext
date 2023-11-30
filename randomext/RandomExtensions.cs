namespace randomext;

public static class RandomExtensions
{
    public static bool NextBool(this Random random) => random.Next() % 2 == 0;

    public static byte NextByte(this Random random, byte min = byte.MinValue, byte max = byte.MaxValue) => 
        (byte)random.Next(min, max);

    public static sbyte NextSByte(this Random random, sbyte min = sbyte.MinValue, sbyte max = sbyte.MaxValue) => 
        (sbyte)random.Next(min, max);

    public static ushort NextUInt16(this Random random, ushort min = ushort.MinValue, ushort max = ushort.MaxValue) => 
        (ushort)random.Next(min, max);

    public static short NextInt16(this Random random, short min = short.MinValue, short max = short.MaxValue) => 
        (short)random.Next(min, max);

    public static int NextInt32(this Random random, int min = int.MinValue, int max = int.MaxValue) => 
        random.Next(min, max);

    public static uint NextUInt32(this Random random, uint min = uint.MinValue, uint max = uint.MaxValue) => 
        (uint)random.NextInt64(min, max);

    public static ulong NextUInt64(this Random random, ulong min = ulong.MinValue, ulong max = ulong.MaxValue)
    {
        var bytes = new byte[8];
        random.NextBytes(bytes);
        var x = BitConverter.ToUInt64(bytes);
        if (x < min) return (x + min) % max;
        return x % max;
    }

    public static char NextChar(this Random random, char min = char.MinValue, char max = char.MaxValue) => 
        (char)random.NextUInt16(min, max);
}