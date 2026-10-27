using System.Text;

namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Reverse Shuffle Merge — <c>s</c> is a merge of reverse(A) with a shuffle of A; find the
/// lexicographically smallest A. A takes half of each letter, read from the end of <c>s</c>.
/// Build it with a monotonic stack: drop a larger letter from the top whenever enough copies
/// of it remain to be skipped. O(n).
/// https://www.hackerrank.com/challenges/reverse-shuffle-merge
/// </summary>
public static class ReverseShuffleMerge
{
    public static string Solve(string s)
    {
        var needed = new int[26];
        foreach (var c in s)
        {
            needed[c - 'a']++;
        }

        var skippable = new int[26];
        for (int i = 0; i < 26; i++)
        {
            needed[i] /= 2;
            skippable[i] = needed[i];
        }

        var result = new StringBuilder(s.Length / 2);

        for (int i = s.Length - 1; i >= 0; i--)
        {
            int letter = s[i] - 'a';

            if (needed[letter] == 0)
            {
                skippable[letter]--;
                continue;
            }

            while (result.Length > 0 && result[^1] > s[i] && skippable[result[^1] - 'a'] > 0)
            {
                int dropped = result[^1] - 'a';
                result.Length--;
                needed[dropped]++;
                skippable[dropped]--;
            }

            result.Append(s[i]);
            needed[letter]--;
        }

        return result.ToString();
    }
}
