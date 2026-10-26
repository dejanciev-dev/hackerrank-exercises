namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Apple and Orange — count how many fallen apples and oranges land on Sam's house,
/// which spans the inclusive range [s, t].
/// https://www.hackerrank.com/challenges/apple-and-orange
/// </summary>
public static class AppleAndOrange
{
    public static (int Apples, int Oranges) Solve(int s, int t, int a, int b, IReadOnlyList<int> apples, IReadOnlyList<int> oranges)
    {
        return (CountOnHouse(s, t, a, apples), CountOnHouse(s, t, b, oranges));
    }

    private static int CountOnHouse(int s, int t, int tree, IReadOnlyList<int> distances)
    {
        int count = 0;
        foreach (var distance in distances)
        {
            int position = tree + distance;
            if (position >= s && position <= t)
            {
                count++;
            }
        }

        return count;
    }
}
