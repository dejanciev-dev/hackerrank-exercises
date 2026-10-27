namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// The Longest Common Subsequence — return one longest common subsequence of two integer
/// sequences (any one is accepted). Classic O(n · m) LCS table, then walk it back from the
/// end to rebuild the sequence.
/// https://www.hackerrank.com/challenges/dynamic-programming-classics-the-longest-common-subsequence
/// </summary>
public static class LongestCommonSubsequence
{
    public static int[] Solve(IReadOnlyList<int> a, IReadOnlyList<int> b)
    {
        var length = new int[a.Count + 1, b.Count + 1];

        for (int i = 1; i <= a.Count; i++)
        {
            for (int j = 1; j <= b.Count; j++)
            {
                length[i, j] = a[i - 1] == b[j - 1]
                    ? length[i - 1, j - 1] + 1
                    : Math.Max(length[i - 1, j], length[i, j - 1]);
            }
        }

        var result = new int[length[a.Count, b.Count]];
        int write = result.Length - 1;

        for (int i = a.Count, j = b.Count; i > 0 && j > 0;)
        {
            if (a[i - 1] == b[j - 1])
            {
                result[write--] = a[i - 1];
                i--;
                j--;
            }
            else if (length[i - 1, j] >= length[i, j - 1])
            {
                i--;
            }
            else
            {
                j--;
            }
        }

        return result;
    }
}
