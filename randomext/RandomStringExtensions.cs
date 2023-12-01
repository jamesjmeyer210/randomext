namespace randomext;

public static class RandomStringExtensions
{
    public static string Next(this RandomType<string> self, CharSet charSet = CharSet.Any, int size = 100) =>
        new(self.As<char>().NextArray(size, r => r.Next(charSet)));

    public static string NextBase64(this RandomType<string> self, 
        int bytes = 100, 
        Base64FormattingOptions formattingOptions = Base64FormattingOptions.None) =>
        Convert.ToBase64String(self.As<byte>().NextBytes(bytes));

    public static string NextHexString(this RandomType<string> self, int bytes = 100) =>
        Convert.ToHexString(self.As<byte>().NextBytes(bytes));
}