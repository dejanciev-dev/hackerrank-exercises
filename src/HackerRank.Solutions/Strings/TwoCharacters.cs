namespace HackerRank.Solutions.Strings;

/// <summary>
/// Two Characters — keep only two distinct letters so they strictly alternate; return the
/// longest possible result length, or 0. Tries every pair of letters present in the string.
/// https://www.hackerrank.com/challenges/two-characters
/// </summary>
public static class TwoCharacters
{
    public static int Solve(string s)
    {
        var letters = s.Distinct().ToArray();
        int best = 0;

        for (int i = 0; i < letters.Length; i++)
        {
            for (int j = i + 1; j < letters.Length; j++)
            {
                int length = AlternatingLength(s, letters[i], letters[j]);
                best = Math.Max(best, length);
            }
        }

        return best;
    }

    private static int AlternatingLength(string s, char a, char b)
    {
        char previous = '\0';
        int length = 0;

        foreach (var c in s)
        {
            if (c != a && c != b)
            {
                continue;
            }

            if (c == previous)
            {
                return 0;
            }

            previous = c;
            length++;
        }

        return length >= 2 ? length : 0;
    }
}
