namespace HackerRank.Solutions.Warmup;

/// <summary>
/// Compare the Triplets — award a point to Alice or Bob for every category in which
/// their rating is strictly higher, and return [alicePoints, bobPoints].
/// https://www.hackerrank.com/challenges/compare-the-triplets
/// </summary>
public static class CompareTheTriplets
{
    public static int[] Solve(IReadOnlyList<int> a, IReadOnlyList<int> b)
    {
        int alice = 0;
        int bob = 0;

        for (int i = 0; i < a.Count; i++)
        {
            if (a[i] > b[i]) alice++;
            if (a[i] < b[i]) bob++;
        }

        return [alice, bob];
    }
}
