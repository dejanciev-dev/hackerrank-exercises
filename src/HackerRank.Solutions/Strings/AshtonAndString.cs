namespace HackerRank.Solutions.Strings;

/// <summary>
/// Ashton and String — sort all distinct substrings, concatenate them, and return the k-th
/// character (1-based). Walking the suffix array in order lists the distinct substrings in
/// sorted order: suffix i adds its prefixes longer than lcp[i], each new as a substring.
/// Skip whole suffixes by their total length until k falls inside one.
/// O(n log² n) to build the suffix array.
/// https://www.hackerrank.com/challenges/ashton-and-string
/// </summary>
public static class AshtonAndString
{
    public static char Solve(string s, long k)
    {
        var order = SuffixArray.Build(s);
        var lcp = SuffixArray.Lcp(s, order);

        for (int i = 0; i < order.Length; i++)
        {
            long length = s.Length - order[i];
            long shared = lcp[i];
            long characters = length * (length + 1) / 2 - shared * (shared + 1) / 2;

            if (k > characters)
            {
                k -= characters;
                continue;
            }

            for (long prefix = shared + 1; ; prefix++)
            {
                if (k <= prefix)
                {
                    return s[order[i] + (int)k - 1];
                }

                k -= prefix;
            }
        }

        throw new ArgumentOutOfRangeException(nameof(k), "k is past the end of the concatenation.");
    }
}
