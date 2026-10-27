namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Tara's Beautiful Permutations — every value appears once or twice; count the distinct
/// arrangements with no two equal values next to each other, modulo 1e9+7. With k values
/// appearing twice, inclusion–exclusion over the j pairs forced to be adjacent (each glued
/// into one block) gives Σ_j (-1)^j · C(k, j) · (n - j)! / 2^(k - j). O(n).
/// https://www.hackerrank.com/challenges/taras-beautiful-permutations
/// </summary>
public static class TarasBeautifulPermutations
{
    public static long Solve(IReadOnlyList<int> a)
    {
        const long Mod = ModularMath.Prime;
        int n = a.Count;
        int k = a.GroupBy(v => v).Count(g => g.Count() == 2);

        var factorial = new long[n + 1];
        factorial[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial[i] = factorial[i - 1] * i % Mod;
        }

        long inverseTwo = (Mod + 1) / 2;
        var inversePowerOfTwo = new long[k + 1];
        inversePowerOfTwo[0] = 1;
        for (int i = 1; i <= k; i++)
        {
            inversePowerOfTwo[i] = inversePowerOfTwo[i - 1] * inverseTwo % Mod;
        }

        long total = 0;
        long chooseJ = 1; // C(k, j), built up incrementally
        for (int j = 0; j <= k; j++)
        {
            long term = chooseJ * factorial[n - j] % Mod * inversePowerOfTwo[k - j] % Mod;
            total = (total + (j % 2 == 0 ? term : Mod - term)) % Mod;
            chooseJ = chooseJ * (k - j) % Mod * ModularMath.Power(j + 1, Mod - 2, Mod) % Mod;
        }

        return total;
    }
}
