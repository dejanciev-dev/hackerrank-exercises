namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Lucky Number Eight — count the subsequences of a digit string (leading zeros allowed)
/// whose value is divisible by 8, modulo 1e9+7. Track how many subsequences so far have
/// each remainder mod 8. A new digit can extend any of them (r → 10r + d) or start a new
/// one. O(8n).
/// https://www.hackerrank.com/challenges/lucky-number-eight
/// </summary>
public static class LuckyNumberEight
{
    private const long Mod = 1_000_000_007;

    public static long Solve(string number)
    {
        var ways = new long[8];

        foreach (var c in number)
        {
            int digit = c - '0';
            var next = (long[])ways.Clone();

            for (int r = 0; r < 8; r++)
            {
                int extended = (r * 10 + digit) % 8;
                next[extended] = (next[extended] + ways[r]) % Mod;
            }

            next[digit % 8] = (next[digit % 8] + 1) % Mod;
            ways = next;
        }

        return ways[0];
    }
}
