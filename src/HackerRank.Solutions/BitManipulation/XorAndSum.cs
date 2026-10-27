namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// Xor and Sum — Σ_{i=0..314159} (a XOR (b &lt;&lt; i)) for binary strings a and b, modulo 1e9+7.
/// Use x XOR y = x + y - 2(x AND y). The a and b terms have closed forms. For the AND term,
/// each set bit p of a pairs with every set bit of b that some shift i moves onto p. That's
/// a range of b's bits, counted with prefix sums. O(|a| + |b| + shifts).
/// https://www.hackerrank.com/challenges/xor-and-sum
/// </summary>
public static class XorAndSum
{
    private const long Mod = 1_000_000_007;

    public static long Solve(string a, string b, int shifts = 314159)
    {
        // Bits indexed from the least significant end.
        var bitsA = a.Reverse().Select(c => c == '1').ToArray();
        var bitsB = b.Reverse().Select(c => c == '1').ToArray();

        int maxPower = Math.Max(bitsA.Length, bitsB.Length + shifts) + 1;
        var power = new long[maxPower + 1];
        power[0] = 1;
        for (int i = 1; i <= maxPower; i++)
        {
            power[i] = power[i - 1] * 2 % Mod;
        }

        long valueA = 0;
        for (int p = 0; p < bitsA.Length; p++)
        {
            if (bitsA[p]) valueA = (valueA + power[p]) % Mod;
        }

        long valueB = 0;
        var onesB = new int[bitsB.Length + 1];
        for (int p = 0; p < bitsB.Length; p++)
        {
            if (bitsB[p]) valueB = (valueB + power[p]) % Mod;
            onesB[p + 1] = onesB[p] + (bitsB[p] ? 1 : 0);
        }

        long terms = shifts + 1;
        long total = valueA * (terms % Mod) % Mod;
        total = (total + valueB * ((power[shifts + 1] - 1 + Mod) % Mod)) % Mod;

        long and = 0;
        for (int p = 0; p < bitsA.Length; p++)
        {
            if (!bitsA[p])
            {
                continue;
            }

            // Shift i moves b's bit p - i onto p, for i in [0, shifts].
            int low = Math.Max(0, p - shifts);
            int high = Math.Min(p, bitsB.Length - 1);
            if (low <= high)
            {
                and = (and + power[p] * (onesB[high + 1] - onesB[low])) % Mod;
            }
        }

        return ((total - 2 * and) % Mod + Mod) % Mod;
    }
}
