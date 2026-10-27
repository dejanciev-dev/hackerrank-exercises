namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Substring Diff — the longest L such that some length-L substrings of s1 and s2 differ in at
/// most <c>k</c> positions. Each pair of aligned substrings lies on a diagonal (a fixed
/// offset between the two start indices). Along each diagonal, a sliding window with at most
/// k mismatches finds the longest run. O(n²) time, O(1) memory.
/// https://www.hackerrank.com/challenges/substring-diff
/// </summary>
public static class SubstringDiff
{
    public static int Solve(int k, string s1, string s2)
    {
        int n = s1.Length;
        int best = 0;

        for (int offset = -(n - 1); offset < n; offset++)
        {
            int i0 = Math.Max(0, -offset);
            int length = n - Math.Abs(offset);
            int mismatches = 0;

            for (int left = 0, right = 0; right < length; right++)
            {
                if (s1[i0 + right] != s2[i0 + offset + right])
                {
                    mismatches++;
                }

                while (mismatches > k)
                {
                    if (s1[i0 + left] != s2[i0 + offset + left])
                    {
                        mismatches--;
                    }

                    left++;
                }

                best = Math.Max(best, right - left + 1);
            }
        }

        return best;
    }
}
