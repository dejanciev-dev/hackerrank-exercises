namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// nCr Table — row <c>n</c> of Pascal's triangle modulo 10^9. The modulus isn't prime, so
/// there are no modular inverses; build the rows by addition instead, in one array updated
/// right to left. O(n²).
/// https://www.hackerrank.com/challenges/ncr-table
/// </summary>
public static class NcrTable
{
    private const long Mod = 1_000_000_000;

    public static long[] Solve(int n)
    {
        var row = new long[n + 1];
        row[0] = 1;

        for (int i = 1; i <= n; i++)
        {
            for (int k = i; k > 0; k--)
            {
                row[k] = (row[k] + row[k - 1]) % Mod;
            }
        }

        return row;
    }
}
