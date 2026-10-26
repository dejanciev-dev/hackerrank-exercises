namespace HackerRank.Solutions.Search;

/// <summary>
/// Sherlock and Array — is there an index where the sum of the elements to its left equals the
/// sum to its right? Compare a running prefix sum with the remaining total.
/// https://www.hackerrank.com/challenges/sherlock-and-array
/// </summary>
public static class SherlockAndArray
{
    public static string Solve(IReadOnlyList<int> arr)
    {
        long total = arr.Sum(value => (long)value);
        long left = 0;

        foreach (var value in arr)
        {
            if (left == total - left - value)
            {
                return "YES";
            }

            left += value;
        }

        return "NO";
    }
}
