namespace randomext;

public static class RandomCharExtensions
{
    public static char Next(this RandomType<char> self, char min = char.MinValue, char max = char.MaxValue) =>
        self.Inner.NextChar(min, max);
    
    public static char Next(this RandomType<char> self, CharSet set = CharSet.Any)
    {
        return set switch
        {
            CharSet.Ascii => self.Inner.NextChar('\0', '\u007f'),
            CharSet.Numeric => self.Inner.NextChar('0', '9'),
            CharSet.Alpha => self.Inner.NextChar('A', 'z'),
            CharSet.AlphaLower => self.Inner.NextChar('a', 'z'),
            CharSet.AlphaUpper => self.Inner.NextChar('A', 'Z'),
            CharSet.AlphaNumeric => self.Inner.NextBool() ? self.Next(CharSet.Numeric) : self.Next(CharSet.Alpha),
            CharSet.Special => self.Inner.NextInt32(0, 4) switch
            {
                0 => self.Inner.NextChar('!', '/'),
                1 => self.Inner.NextChar(':', '@'),
                2 => self.Inner.NextChar('[', '`'),
                3 => self.Inner.NextChar('{', '~'),
                _ => throw new NotImplementedException()
            },
            CharSet.Invisible => self.Inner.NextChar('\u0000', '\u001F'),
            CharSet.Readable => self.Inner.NextChar(' ', '~'),
            _ => self.Inner.NextChar()
        };
    }

    public static char[] NextChars(this RandomType<char> self, int size, CharSet set = CharSet.Any) =>
        self.NextArray(size, r => r.Next(set));
}