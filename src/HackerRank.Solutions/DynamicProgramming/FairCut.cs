namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Fair Cut — give exactly <c>k</c> of the numbers to Li and the rest to Lu, minimising
/// Σ |a_i - a_j| over pairs (i to Li, j to Lu). Process the numbers sorted, so each value's
/// contribution is fixed by how many of the other group come before it (each adds +a) and
/// after it (each adds -a). best[j] = least unfairness with j numbers given to Li so far.
/// O(n · k).
/// https://www.hackerrank.com/challenges/fair-cut
/// </summary>
public static class FairCut
{
    public static long Solve(int k, IReadOnlyList<long> a)
    {
        var sorted = a.Order().ToArray();
        int n = sorted.Length;
        int others = n - k;

        var best = new long[k + 1];
        Array.Fill(best, long.MaxValue);
        best[0] = 0;

        for (int i = 0; i < n; i++)
        {
            var next = new long[k + 1];
            Array.Fill(next, long.MaxValue);

            for (int j = 0; j <= Math.Min(i, k); j++)
            {
                if (best[j] == long.MaxValue)
                {
                    continue;
                }

                int luBefore = i - j;
                if (luBefore < others)
                {
                    // To Lu: it pairs with the j Li numbers before it and the k - j after it.
                    next[j] = Math.Min(next[j], best[j] + sorted[i] * (j - (k - j)));
                }

                if (j < k)
                {
                    // To Li: it pairs with the Lu numbers before it and the ones still to come.
                    long toLi = best[j] + sorted[i] * (luBefore - (others - luBefore));
                    next[j + 1] = Math.Min(next[j + 1], toLi);
                }
            }

            best = next;
        }

        return best[k];
    }
}
