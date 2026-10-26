namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Subarray Division (Birthday Chocolate) — count contiguous segments of length <c>m</c>
/// whose squares sum to <c>d</c>. Uses a sliding window for O(n).
/// https://www.hackerrank.com/challenges/the-birthday-bar
/// </summary>
public static class SubarrayDivision
{
    public static int Solve(IReadOnlyList<int> s, int d, int m)
    {
        int count = 0;
        int windowSum = 0;

        for (int i = 0; i < s.Count; i++)
        {
            windowSum += s[i];

            if (i >= m)
            {
                windowSum -= s[i - m];
            }

            if (i >= m - 1 && windowSum == d)
            {
                count++;
            }
        }

        return count;
    }
}
