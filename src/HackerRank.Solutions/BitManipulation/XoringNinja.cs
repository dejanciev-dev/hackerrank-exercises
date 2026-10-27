namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// Xoring Ninja — the sum of the XORs of every non-empty subset, modulo 1e9+7. A bit that
/// appears in any element is set in the XOR of exactly half of the 2^n subsets, so the answer
/// is (OR of all elements) · 2^(n-1). O(n).
/// https://www.hackerrank.com/challenges/xoring-ninja
/// </summary>
public static class XoringNinja
{
    private const long Mod = 1_000_000_007;

    public static long Solve(IReadOnlyList<int> arr)
    {
        long or = 0;
        foreach (var value in arr)
        {
            or |= (uint)value;
        }

        long result = or % Mod;
        for (int i = 1; i < arr.Count; i++)
        {
            result = result * 2 % Mod;
        }

        return result;
    }
}
