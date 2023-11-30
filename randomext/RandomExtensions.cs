namespace randomext;

public static class RandomExtensions
{
    public static bool NextBool(this Random random) => random.Next() % 2 == 0;

    public static byte NextByte(this Random random) => (byte)(random.Next() % byte.MaxValue);

    public static sbyte NextSByte(this Random random) => (sbyte)(random.Next() % byte.MaxValue);

    public static ushort NextUInt16(this Random random) => (ushort)(random.Next() % ushort.MaxValue);

    public static short NextInt16(this Random random) => (short)(random.Next() % ushort.MaxValue);

    public static int NextInt32(this Random random) => random.Next();

    public static uint NextUInt32(this Random random) => (uint)(random.NextInt64() % uint.MaxValue);

    public static char NextChar(this Random random) => (char)random.NextUInt16();
}