namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Tower Breakers, Again! — a move replaces a tower of height x with z towers of height y,
/// where y · z = x and z &gt; 1; whoever can't move loses. z equal towers XOR to g(y) for odd z
/// and to 0 for even z, so g(x) = mex over divisors z &gt; 1 of (z odd ? g(x / z) : 0),
/// memoised. Player 1 wins when the XOR over all towers is non-zero.
/// https://www.hackerrank.com/challenges/tower-breakers-again-1
/// </summary>
public static class TowerBreakersAgain
{
    public static int Solve(IReadOnlyList<int> h)
    {
        var memo = new Dictionary<int, int>();
        int nimSum = 0;
        foreach (var height in h)
        {
            nimSum ^= Grundy(height, memo);
        }

        return nimSum != 0 ? 1 : 2;
    }

    private static int Grundy(int x, Dictionary<int, int> memo)
    {
        if (memo.TryGetValue(x, out int known))
        {
            return known;
        }

        var reachable = new HashSet<int>();
        for (int d = 1; d * d <= x; d++)
        {
            if (x % d != 0)
            {
                continue;
            }

            foreach (var z in new[] { d, x / d })
            {
                if (z > 1)
                {
                    reachable.Add(z % 2 == 1 ? Grundy(x / z, memo) : 0);
                }
            }
        }

        int mex = 0;
        while (reachable.Contains(mex))
        {
            mex++;
        }

        return memo[x] = mex;
    }
}
