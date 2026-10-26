namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Divisible Sum Pairs — count pairs (i &lt; j) where ar[i] + ar[j] is divisible by k.
/// Counts remainders in a single pass for O(n + k).
/// https://www.hackerrank.com/challenges/divisible-sum-pairs
/// </summary>
public static class DivisibleSumPairs
{
    public static int Solve(int k, IReadOnlyList<int> ar)
    {
        var remainders = new int[k];
        int pairs = 0;

        foreach (var value in ar)
        {
            int remainder = value % k;
            int complement = (k - remainder) % k;
            pairs += remainders[complement];
            remainders[remainder]++;
        }

        return pairs;
    }
}
