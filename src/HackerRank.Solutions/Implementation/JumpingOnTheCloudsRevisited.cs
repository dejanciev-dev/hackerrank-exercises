namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Jumping on the Clouds: Revisited — jump <c>k</c> clouds at a time around a circle until back
/// at cloud 0. Each jump costs 1 energy, plus 2 more when landing on a thundercloud.
/// https://www.hackerrank.com/challenges/jumping-on-the-clouds-revisited
/// </summary>
public static class JumpingOnTheCloudsRevisited
{
    public static int Solve(IReadOnlyList<int> c, int k)
    {
        int energy = 100;
        int position = 0;

        do
        {
            position = (position + k) % c.Count;
            energy -= 1 + 2 * c[position];
        }
        while (position != 0);

        return energy;
    }
}
