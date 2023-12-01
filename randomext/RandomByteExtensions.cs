namespace randomext;

public static class RandomByteExtensions
{ 
    public static byte[] NextBytes(this RandomType<byte> self, 
        int size = 100, 
        byte min = byte.MinValue, 
        byte max = byte.MaxValue) => 
        self.NextArray(size, r => r.Next(min, max));
}