namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Absolute Permutation — the lexicographically smallest permutation of 1..n with
/// |pos[i] - i| = k for every i, or [-1]. Positions pair up in blocks of k: the first k values
/// move up by k and the next k move down by k, which requires n to be divisible by 2k.
/// https://www.hackerrank.com/challenges/absolute-permutation
/// </summary>
public static class AbsolutePermutation
{
    public static int[] Solve(int n, int k)
    {
        if (k == 0)
        {
            return Enumerable.Range(1, n).ToArray();
        }

        if (n % (2 * k) != 0)
        {
            return [-1];
        }

        var result = new int[n];
        for (int i = 1; i <= n; i++)
        {
            bool shiftUp = (i - 1) / k % 2 == 0;
            result[i - 1] = shiftUp ? i + k : i - k;
        }

        return result;
    }
}
