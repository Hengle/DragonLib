﻿namespace DragonLib.Text;

// https://github.com/tompazourek/NaturalSort.Extension/blob/7e99f4e52b2e8e16e3de542f2fce547d4abe047a/src/NaturalSort.Extension/NaturalSortComparer.cs
// additions: non-uniform descending number and string sorting

/// <summary>
///     Creates a string comparer with natural sorting functionality
///     which allows it to sort numbers inside the strings as numbers, not as letters.
///     (e.g. "1", "2", "10" instead of "1", "10", "2").
///     It uses either a <seealso cref="System.StringComparison"/> (preferred) or arbitrary
///     <see cref="System.Collections.Generic.IComparer{T}"/> string comparer for the comparisons.
/// </summary>
public class NaturalStringComparer : IComparer<string> {
    /// <summary>
    ///     String comparison used for comparing strings.
    ///     Used if <see cref="UnderlyingStringComparer"/> is null.
    /// </summary>
    private readonly StringComparison StringComparison;

    /// <summary>
    ///     String comparer used for comparing strings.
    /// </summary>
    private readonly IComparer<string>? UnderlyingStringComparer;

    private readonly bool NumberDirectionDescending;

    private readonly bool StringDirectionDescending;

    // Token values (not an enum as a performance micro-optimization)
    private const byte TokenNone = 0;
    private const byte TokenOther = 1;
    private const byte TokenDigits = 2;
    private const byte TokenLetters = 3;

    /// <summary>
    ///     Constructs comparer with a <seealso cref="System.StringComparison"/> as the inner mechanism.
    ///     Prefer this to
    ///     <see cref="NaturalStringComparer(System.Collections.Generic.IComparer{string}, System.Boolean, System.Boolean)"/>
    ///     if possible.
    /// </summary>
    /// <param name="stringComparison">String comparison to use</param>
    /// <param name="numberDescending">Whether or not to process digits in descending order</param>
    /// <param name="stringDescending">Whether or not to process strings in descending order</param>
    public NaturalStringComparer(StringComparison stringComparison, bool numberDescending = false, bool stringDescending = false) {
        StringComparison = stringComparison;
        NumberDirectionDescending = numberDescending;
        StringDirectionDescending = stringDescending;
    }

    /// <summary>
    ///     Constructs comparer with a <seealso cref="IComparer{T}"/> string comparer as the inner mechanism.
    ///     Prefer <see cref="NaturalStringComparer(System.StringComparison, System.Boolean, System.Boolean)"/> if possible.
    /// </summary>
    /// <param name="underlyingStringComparer">String comparer to wrap</param>
    /// <param name="numberDescending">Whether or not to process digits in descending order</param>
    /// <param name="stringDescending">Whether or not to process strings in descending order</param>
    public NaturalStringComparer(IComparer<string> underlyingStringComparer, bool numberDescending = false, bool stringDescending = false) {
        UnderlyingStringComparer = underlyingStringComparer;
        NumberDirectionDescending = numberDescending;
        StringDirectionDescending = stringDescending;
    }

    /// <inheritdoc/>
#if RELEASE
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
#endif
    public int Compare(string? str1, string? str2) {
        if (str1 == str2) {
            return 0;
        }

        if (str1 == null) {
            return -1;
        }

        if (str2 == null) {
            return 1;
        }

        var strLength1 = str1.Length;
        var strLength2 = str2.Length;

        var startIndex1 = 0;
        var startIndex2 = 0;

        while (true) {
            // get next token from string 1
            var endIndex1 = startIndex1;
            var token1 = TokenNone;
            while (endIndex1 < strLength1) {
                var charToken = GetTokenFromChar(str1[endIndex1]);
                if (token1 == TokenNone) {
                    token1 = charToken;
                } else if (token1 != charToken) {
                    break;
                }

                endIndex1++;
            }

            // get next token from string 2
            var endIndex2 = startIndex2;
            var token2 = TokenNone;
            while (endIndex2 < strLength2) {
                var charToken = GetTokenFromChar(str2[endIndex2]);
                if (token2 == TokenNone) {
                    token2 = charToken;
                } else if (token2 != charToken) {
                    break;
                }

                endIndex2++;
            }

            // if the token kinds are different, compare just the token kind
            var tokenCompare = token1.CompareTo(token2);
            if (tokenCompare != 0) {
                return tokenCompare;
            }

            // now we know that both tokens are the same kind

            // didn't find any more tokens, return that they're equal
            if (token1 == TokenNone) {
                return 0;
            }

            var rangeLength1 = endIndex1 - startIndex1;
            var rangeLength2 = endIndex2 - startIndex2;

            if (token1 == TokenDigits) {
                // compare both tokens as numbers
                var maxLength = Math.Max(rangeLength1, rangeLength2);

                // both spans will get padded by zeroes on the left to be the same length
                const char paddingChar = '0';
                var paddingLength1 = maxLength - rangeLength1;
                var paddingLength2 = maxLength - rangeLength2;

                for (var i = 0; i < maxLength; i++) {
                    var digit1 = i < paddingLength1 ? paddingChar : str1[startIndex1 + i - paddingLength1];
                    var digit2 = i < paddingLength2 ? paddingChar : str2[startIndex2 + i - paddingLength2];

                    if (NumberDirectionDescending) {
                        (digit1, digit2) = (digit2, digit1);
                    }

                    var digitCompare = digit1.CompareTo(digit2);
                    if (digitCompare != 0) {
                        return digitCompare;
                    }
                }

                if (NumberDirectionDescending) {
                    (paddingLength1, paddingLength2) = (paddingLength2, paddingLength1);
                }

                // if the numbers are equal, we compare how much we padded the strings
                var paddingCompare = paddingLength1.CompareTo(paddingLength2);
                if (paddingCompare != 0) {
                    return paddingCompare;
                }
            } else if (UnderlyingStringComparer is not null) {
                // compare both tokens as strings
                var tokenString1 = str1.Substring(startIndex1, rangeLength1);
                var tokenString2 = str2.Substring(startIndex2, rangeLength2);

                if (StringDirectionDescending) {
                    (tokenString1, tokenString2) = (tokenString2, tokenString1);
                }

                var stringCompare = UnderlyingStringComparer.Compare(tokenString1, tokenString2);
                if (stringCompare != 0) {
                    return stringCompare;
                }
            } else {
                // use string comparison
                var minLength = Math.Min(rangeLength1, rangeLength2);

                var stringCompare = StringDirectionDescending ? string.Compare(str2, startIndex2, str1, startIndex1, minLength, StringComparison) : string.Compare(str1, startIndex1, str2, startIndex2, minLength, StringComparison);

                if (stringCompare == 0) {
                    stringCompare = rangeLength1 - rangeLength2;
                }

                if (stringCompare != 0) {
                    return stringCompare;
                }
            }

            startIndex1 = endIndex1;
            startIndex2 = endIndex2;
        }
    }

#if RELEASE
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#endif
    private static byte GetTokenFromChar(char c) =>
        c >= 'a'
            ? c <= 'z'
                ? TokenLetters
                : c < 128
                    ? TokenOther
                    : char.IsLetter(c)
                        ? TokenLetters
                        : TokenOther
            : c >= 'A'
                ? c <= 'Z'
                    ? TokenLetters
                    : TokenOther
                : c is >= '0' and <= '9'
                    ? TokenDigits
                    : TokenOther;
}
