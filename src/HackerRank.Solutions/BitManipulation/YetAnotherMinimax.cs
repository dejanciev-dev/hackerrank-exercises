namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// Yet Another Minimax Problem — order the array to minimise the largest XOR of adjacent
/// elements. Above the highest bit where the values differ, every XOR is 0. At that bit the
/// array splits into two groups, and some adjacent pair must cross between them, so the best
/// is the smallest XOR of one value from each group. O(|A| · |B|).
/// https://www.hackerrank.com/challenges/yet-another-minimax-problem
/// </summary>
public static class YetAnotherMinimax
{
    public static int Solve(IReadOnlyList<int> a)
    {
        int differing = 0;
        foreach (var value in a)
        {
            differing |= value ^ a[0];
        }

        if (differing == 0)
        {
            return 0;
        }

        int bit = 1 << (31 - int.LeadingZeroCount(differing));
        var withBit = a.Where(v => (v & bit) != 0).ToArray();
        var withoutBit = a.Where(v => (v & bit) == 0).ToArray();

        return withBit.Min(x => withoutBit.Min(y => x ^ y));
    }
}
