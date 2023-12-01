namespace randomext;

public static class RandomCharExtensions
{
    public static char Next(this RandomType<char> self, CharGroup group)
    {
        return group switch
        {
            CharGroup.Ascii => self.Inner.NextChar('\0', '\u007f'),
            CharGroup.Numeric => self.Inner.NextChar('0', '9'),
            CharGroup.Alpha => self.Inner.NextChar('A', 'z'),
            CharGroup.AlphaLower => self.Inner.NextChar('a', 'z'),
            CharGroup.AlphaUpper => self.Inner.NextChar('A', 'Z'),
            CharGroup.AlphaNumeric => self.Inner.NextBool() ? self.Next(CharGroup.Numeric) : self.Next(CharGroup.Alpha),
            CharGroup.Special => self.Inner.NextInt32(0, 3) switch
            {
                0 => self.Inner.NextChar('!', '/'),
                1 => self.Inner.NextChar(':', '@'),
                2 => self.Inner.NextChar('[', '`'),
                3 => self.Inner.NextChar('{', '~'),
                _ => throw new NotImplementedException()
            },
            CharGroup.Invisible => self.Inner.NextChar('\u0000', '\u001F'),
            CharGroup.Readable => self.Inner.NextChar(' ', '~'),
            _ => throw new NotImplementedException()
        };
    }
}