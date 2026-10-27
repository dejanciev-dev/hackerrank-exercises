namespace HackerRank.Solutions.Strings;

/// <summary>
/// Game of Thrones - II — number of distinct palindromic anagrams of the string, modulo
/// 1e9+7. A palindrome is fixed by its left half, so with c_i copies of each letter the
/// count is (Σ⌊c_i/2⌋)! / Π(⌊c_i/2⌋!). Any letter left over goes in the middle.
/// https://www.hackerrank.com/challenges/game-of-throne-ii
/// </summary>
public static class GameOfThronesII
{
    private const long Mod = 1_000_000_007;

    public static long Solve(string s)
    {
        var counts = new int[26];
        foreach (var c in s)
        {
            counts[c - 'a']++;
        }

        int half = counts.Sum(c => c / 2);
        var factorial = new long[half + 1];
        factorial[0] = 1;
        for (int i = 1; i <= half; i++)
        {
            factorial[i] = factorial[i - 1] * i % Mod;
        }

        long denominator = 1;
        foreach (var count in counts)
        {
            denominator = denominator * factorial[count / 2] % Mod;
        }

        return factorial[half] * Mathematics.ModularMath.Power(denominator, Mod - 2, Mod) % Mod;
    }
}
