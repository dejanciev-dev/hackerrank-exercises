namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Sam and Substrings — sum of all numeric substrings of a digit string, modulo 10^9 + 7.
/// If f(i) is the sum of substrings ending at i, then f(i) = 10·f(i-1) + digit·(i+1). O(n).
/// https://www.hackerrank.com/challenges/sam-and-substrings
/// </summary>
public static class SamAndSubstrings
{
    private const long Modulo = 1_000_000_007;

    public static long Solve(string n)
    {
        long endingHere = 0;
        long total = 0;

        for (int i = 0; i < n.Length; i++)
        {
            int digit = n[i] - '0';
            endingHere = (endingHere * 10 + (long)digit * (i + 1)) % Modulo;
            total = (total + endingHere) % Modulo;
        }

        return total;
    }
}
