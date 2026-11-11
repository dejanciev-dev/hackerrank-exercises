namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// What's Next? — a binary number is given as run lengths, starting with a run of 1s and then
/// alternating; return, in the same form, the smallest larger number with as many 1 bits.
/// The number ends in 0 1^k 0^m (the leading 0 may be an implicit one), and the answer is the
/// same prefix followed by 1 0^(m+1) 1^(k−1). Only the last three runs change. O(runs).
/// https://www.hackerrank.com/challenges/whats-next
/// </summary>
public static class WhatsNext
{
    public static long[] Solve(IReadOnlyList<long> runs)
    {
        // Run i holds 1s when i is even. Find the last run of 1s and the 0s after it.
        int lastOnes = runs.Count % 2 == 1 ? runs.Count - 1 : runs.Count - 2;
        long ones = runs[lastOnes];
        long trailingZeros = lastOnes + 1 < runs.Count ? runs[lastOnes + 1] : 0;

        var result = new List<long>();
        for (int i = 0; i < lastOnes - 1; i++)
        {
            Append(result, i % 2 == 0, runs[i]);
        }

        if (lastOnes > 0)
        {
            Append(result, false, runs[lastOnes - 1] - 1);
        }

        Append(result, true, 1);
        Append(result, false, trailingZeros + 1);
        Append(result, true, ones - 1);
        return [.. result];
    }

    // Runs alternate starting with 1s, so the bit of the last run is implied by the count.
    private static void Append(List<long> result, bool bit, long length)
    {
        if (length == 0)
        {
            return;
        }

        if (result.Count > 0 && (result.Count % 2 == 1) == bit)
        {
            result[^1] += length;
        }
        else
        {
            result.Add(length);
        }
    }
}
