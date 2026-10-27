namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Stone Division — a move splits a pile of x into s equal piles, for some s &gt; 1 in S that
/// divides x; whoever can't move loses. The s identical piles XOR to g(x / s) when s is odd
/// and to 0 when s is even, so g(x) = mex over valid s of (s odd ? g(x / s) : 0). Memoise
/// over the divisors of n reachable this way.
/// https://www.hackerrank.com/challenges/stone-division
/// </summary>
public static class StoneDivision
{
    public static string Solve(long n, IReadOnlyList<long> s)
    {
        var memo = new Dictionary<long, int>();
        return Grundy(n, s, memo) != 0 ? "First" : "Second";
    }

    private static int Grundy(long pile, IReadOnlyList<long> s, Dictionary<long, int> memo)
    {
        if (memo.TryGetValue(pile, out int known))
        {
            return known;
        }

        var reachable = new HashSet<int>();
        foreach (var piles in s)
        {
            if (piles > 1 && pile % piles == 0)
            {
                reachable.Add(piles % 2 == 1 ? Grundy(pile / piles, s, memo) : 0);
            }
        }

        int mex = 0;
        while (reachable.Contains(mex))
        {
            mex++;
        }

        return memo[pile] = mex;
    }
}
