namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Lucky Numbers — a number is lucky when both the sum of its digits and the sum of the squares
/// of its digits are prime. Count the lucky numbers in [a, b] for 1 ≤ a ≤ b ≤ 10^18.
/// Digit DP: ways[len][s][q] counts digit strings of length len with digit sum s and square sum q.
/// To count lucky numbers up to N, walk N's digits; for every smaller digit placed at a position
/// the free suffix is looked up in the table together with the prefix sums. The answer for a
/// range is count(b) − count(a − 1). The table is O(19 · 171 · 1539) and each count is a few
/// million primality lookups.
/// https://www.hackerrank.com/challenges/lucky-numbers
/// </summary>
public static class LuckyNumbers
{
    private const int MaxDigits = 19;
    private const int MaxSum = 9 * MaxDigits;
    private const int MaxSquares = 81 * MaxDigits;

    private static readonly bool[] IsPrimeSum = Sieve(MaxSum);
    private static readonly bool[] IsPrimeSquares = Sieve(MaxSquares);
    private static readonly long[][][] Ways = BuildWays();

    public static long Solve(long a, long b) => CountUpTo(b) - CountUpTo(a - 1);

    private static long CountUpTo(long limit)
    {
        if (limit <= 0)
        {
            return 0;
        }

        var digits = limit.ToString().Select(c => c - '0').ToArray();
        long total = 0;
        int prefixSum = 0;
        int prefixSquares = 0;

        for (int position = 0; position < digits.Length; position++)
        {
            int remaining = digits.Length - position - 1;
            for (int smaller = 0; smaller < digits[position]; smaller++)
            {
                total += CountSuffixes(remaining, prefixSum + smaller, prefixSquares + smaller * smaller);
            }

            prefixSum += digits[position];
            prefixSquares += digits[position] * digits[position];
        }

        // The limit itself.
        if (IsPrimeSum[prefixSum] && IsPrimeSquares[prefixSquares])
        {
            total++;
        }

        return total;
    }

    // Free suffixes of the given length that make the whole number lucky.
    private static long CountSuffixes(int length, int sum, int squares)
    {
        long count = 0;
        var table = Ways[length];
        for (int s = 0; s < table.Length; s++)
        {
            if (!IsPrimeSum[sum + s])
            {
                continue;
            }

            for (int q = 0; q < table[s].Length; q++)
            {
                if (table[s][q] != 0 && IsPrimeSquares[squares + q])
                {
                    count += table[s][q];
                }
            }
        }

        return count;
    }

    private static long[][][] BuildWays()
    {
        var ways = new long[MaxDigits + 1][][];
        ways[0] = [[1]];

        for (int length = 1; length <= MaxDigits; length++)
        {
            ways[length] = new long[9 * length + 1][];
            for (int s = 0; s <= 9 * length; s++)
            {
                ways[length][s] = new long[81 * length + 1];
            }

            for (int s = 0; s < ways[length - 1].Length; s++)
            {
                for (int q = 0; q < ways[length - 1][s].Length; q++)
                {
                    long count = ways[length - 1][s][q];
                    if (count == 0)
                    {
                        continue;
                    }

                    for (int digit = 0; digit <= 9; digit++)
                    {
                        ways[length][s + digit][q + digit * digit] += count;
                    }
                }
            }
        }

        return ways;
    }

    private static bool[] Sieve(int max)
    {
        var prime = new bool[max + 1];
        for (int n = 2; n <= max; n++)
        {
            prime[n] = true;
        }

        for (int n = 2; n * n <= max; n++)
        {
            for (int m = n * n; prime[n] && m <= max; m += n)
            {
                prime[m] = false;
            }
        }

        return prime;
    }
}
