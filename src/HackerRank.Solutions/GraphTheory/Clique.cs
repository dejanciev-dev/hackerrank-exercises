namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Clique — the smallest size of the largest clique that any graph with <c>n</c> nodes and
/// <c>m</c> edges must contain. By Turán's theorem, the most edges a graph can have without a
/// clique of size r + 1 is T(n, r), reached by the balanced complete r-partite graph. So the
/// answer is the smallest r with T(n, r) ≥ m, found by binary search.
/// https://www.hackerrank.com/challenges/clique
/// </summary>
public static class Clique
{
    public static int Solve(int n, long m)
    {
        int low = 1;
        int high = n;

        while (low < high)
        {
            int r = (low + high) / 2;
            if (Turan(n, r) >= m)
            {
                high = r;
            }
            else
            {
                low = r + 1;
            }
        }

        return low;
    }

    /// <summary>Edges of the complete r-partite graph on n nodes with parts as equal as possible.</summary>
    private static long Turan(long n, long r)
    {
        long small = n / r;
        long bigParts = n % r;
        long squares = bigParts * (small + 1) * (small + 1) + (r - bigParts) * small * small;
        return (n * n - squares) / 2;
    }
}
