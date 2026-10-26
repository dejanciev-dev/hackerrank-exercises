namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Fair Rations — giving a loaf always goes to two adjacent people. Return the minimum loaves
/// so everyone has an even number, or "NO" if impossible. Greedily fix odd counts left to right.
/// https://www.hackerrank.com/challenges/fair-rations
/// </summary>
public static class FairRations
{
    public static string Solve(IReadOnlyList<int> b)
    {
        var loaves = b.ToArray();
        int given = 0;

        for (int i = 0; i < loaves.Length - 1; i++)
        {
            if (loaves[i] % 2 != 0)
            {
                loaves[i]++;
                loaves[i + 1]++;
                given += 2;
            }
        }

        return loaves[^1] % 2 == 0 ? given.ToString() : "NO";
    }
}
