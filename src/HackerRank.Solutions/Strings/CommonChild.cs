namespace HackerRank.Solutions.Strings;

/// <summary>
/// Common Child — length of the longest common subsequence of two strings.
/// Dynamic programming with two rolling rows: O(n·m) time, O(m) memory.
/// https://www.hackerrank.com/challenges/common-child
/// </summary>
public static class CommonChild
{
    public static int Solve(string s1, string s2)
    {
        var previous = new int[s2.Length + 1];
        var current = new int[s2.Length + 1];

        for (int i = 1; i <= s1.Length; i++)
        {
            for (int j = 1; j <= s2.Length; j++)
            {
                current[j] = s1[i - 1] == s2[j - 1]
                    ? previous[j - 1] + 1
                    : Math.Max(previous[j], current[j - 1]);
            }

            (previous, current) = (current, previous);
        }

        return previous[s2.Length];
    }
}
