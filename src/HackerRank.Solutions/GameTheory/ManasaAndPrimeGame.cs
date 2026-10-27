namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Manasa and Prime game — a move takes 2, 3, 5, 7, 11 or 13 stones from one pile; whoever
/// can't move loses, and Manasa moves first. The Grundy numbers of a subtraction game are
/// eventually periodic. Compute a prefix of them, find the period, and look up piles of up
/// to 10^18 from that.
/// https://www.hackerrank.com/challenges/manasa-and-prime-game
/// </summary>
public static class ManasaAndPrimeGame
{
    private static readonly int[] Moves = [2, 3, 5, 7, 11, 13];
    private const int Prefix = 2000;
    private static readonly int[] Grundy = BuildGrundy();
    private static readonly int Period = FindPeriod();

    public static string Solve(IReadOnlyList<long> piles)
    {
        int nimSum = 0;
        foreach (var pile in piles)
        {
            nimSum ^= GrundyOf(pile);
        }

        return nimSum != 0 ? "Manasa" : "Sandy";
    }

    internal static int GrundyOf(long pile)
    {
        if (pile < Prefix)
        {
            return Grundy[pile];
        }

        // Fold large piles back into the repeating part of the sequence.
        long start = Prefix / 2;
        return Grundy[start + (pile - start) % Period];
    }

    private static int[] BuildGrundy()
    {
        var grundy = new int[Prefix];
        for (int n = 0; n < Prefix; n++)
        {
            var reachable = Moves.Where(m => m <= n).Select(m => grundy[n - m]).ToHashSet();
            int mex = 0;
            while (reachable.Contains(mex))
            {
                mex++;
            }

            grundy[n] = mex;
        }

        return grundy;
    }

    /// <summary>The smallest period that holds over the second half of the computed prefix.</summary>
    private static int FindPeriod()
    {
        int start = Prefix / 2;
        for (int period = 1; period < start; period++)
        {
            bool holds = true;
            for (int i = start; i + period < Prefix && holds; i++)
            {
                holds = Grundy[i] == Grundy[i + period];
            }

            if (holds)
            {
                return period;
            }
        }

        throw new InvalidOperationException("No period found in the computed prefix.");
    }
}
