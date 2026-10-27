namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Summing Pieces — over every way to split the array into contiguous pieces, add up
/// (piece sum · piece length); modulo 1e9+7. Each element contributes its value times the
/// total length of the pieces it lands in, across all splits. Those totals follow
/// coef(0) = 2^n - 1 and coef(i) = coef(i - 1) + 2^(n-1-i) - 2^(i-1). O(n).
/// https://www.hackerrank.com/challenges/summing-pieces
/// </summary>
public static class SummingPieces
{
    private const long Mod = 1_000_000_007;

    public static long Solve(IReadOnlyList<int> arr)
    {
        int n = arr.Count;
        var powers = new long[n + 1];
        powers[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            powers[i] = powers[i - 1] * 2 % Mod;
        }

        long coefficient = (powers[n] - 1 + Mod) % Mod;
        long total = arr[0] % Mod * coefficient % Mod;

        for (int i = 1; i < n; i++)
        {
            coefficient = ((coefficient + powers[n - 1 - i] - powers[i - 1]) % Mod + Mod) % Mod;
            total = (total + arr[i] % Mod * coefficient) % Mod;
        }

        return total;
    }
}
