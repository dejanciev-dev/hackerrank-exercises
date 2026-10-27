namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// XOR Matrix — each row is built from the previous one by r[j] XOR r[j + 1] (wrapping
/// around); return row m. Over GF(2), 2^k steps at once give r[j] XOR r[j + 2^k], because
/// the binomial coefficients C(2^k, i) are even except at the ends. So apply one jump per
/// set bit of m - 1. O(n log m).
/// https://www.hackerrank.com/challenges/xor-matrix
/// </summary>
public static class XorMatrix
{
    public static long[] Solve(long m, IReadOnlyList<long> firstRow)
    {
        int n = firstRow.Count;
        var row = firstRow.ToArray();
        long steps = m - 1;

        for (int bit = 0; steps >> bit > 0; bit++)
        {
            if (((steps >> bit) & 1) == 0)
            {
                continue;
            }

            int jump = (int)((1L << bit) % n);
            var next = new long[n];
            for (int j = 0; j < n; j++)
            {
                next[j] = row[j] ^ row[(j + jump) % n];
            }

            row = next;
        }

        return row;
    }
}
