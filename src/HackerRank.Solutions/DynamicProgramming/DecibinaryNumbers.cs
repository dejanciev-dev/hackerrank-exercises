namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Decibinary Numbers — decimal digits 0–9 with binary place values (digit i is worth
/// d · 2^i). List every decibinary number sorted by value, then by its own decimal value;
/// return the x-th. ways[p, v] counts representations of v using the lowest p positions.
/// Prefix sums over values find the value of the x-th number. Then digits are chosen from
/// the highest position down, skipping whole blocks of ways[p, rest] at each digit.
/// https://www.hackerrank.com/challenges/decibinary-numbers
/// </summary>
public static class DecibinaryNumbers
{
    private const int Positions = 20;

    public static long[] Solve(IReadOnlyList<long> queries)
    {
        long largest = queries.Max();
        int maxValue = 16;
        long[,] ways;
        long[] cumulative;

        // Grow the value range until it holds at least `largest` numbers.
        while (true)
        {
            ways = BuildWays(maxValue);
            cumulative = new long[maxValue + 1];
            long running = 0;
            for (int v = 0; v <= maxValue; v++)
            {
                running += ways[Positions, v];
                cumulative[v] = running;
            }

            if (running >= largest)
            {
                break;
            }

            maxValue *= 2;
        }

        var results = new long[queries.Count];
        for (int q = 0; q < queries.Count; q++)
        {
            long x = queries[q];
            int value = Array.FindIndex(cumulative, c => c >= x);
            long rank = x - (value > 0 ? cumulative[value - 1] : 0) - 1;

            long number = 0;
            int remaining = value;
            for (int p = Positions - 1; p >= 0; p--)
            {
                for (int digit = 0; digit <= 9; digit++)
                {
                    int rest = remaining - digit * (1 << p);
                    long count = rest >= 0 ? ways[p, rest] : 0;
                    if (rank < count)
                    {
                        number = number * 10 + digit;
                        remaining = rest;
                        break;
                    }

                    rank -= count;
                }
            }

            results[q] = number;
        }

        return results;
    }

    private static long[,] BuildWays(int maxValue)
    {
        var ways = new long[Positions + 1, maxValue + 1];
        ways[0, 0] = 1;

        for (int p = 0; p < Positions; p++)
        {
            long place = 1L << p;
            for (int v = 0; v <= maxValue; v++)
            {
                long total = 0;
                for (int digit = 0; digit <= 9 && digit * place <= v; digit++)
                {
                    total += ways[p, v - digit * place];
                }

                ways[p + 1, v] = total;
            }
        }

        return ways;
    }
}
