using System.Diagnostics.CodeAnalysis;

namespace randomext.Constants;

[SuppressMessage("ReSharper", "StringLiteralTypo")]
internal static class CharacterConstants
{
    internal static readonly char[] Numbers = "0123456789".ToCharArray();
    internal static readonly char[] AlphaLower = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    internal static readonly char[] AlphaUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    internal static char[] Alpha => "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
}