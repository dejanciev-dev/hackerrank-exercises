namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Jumping on the Clouds — minimum jumps (of 1 or 2) to reach the last cloud while avoiding
/// thunderheads (1). Greedily jumping 2 whenever possible is optimal.
/// https://www.hackerrank.com/challenges/jumping-on-the-clouds
/// </summary>
public static class JumpingOnTheClouds
{
    public static int Solve(IReadOnlyList<int> c)
    {
        int jumps = 0;
        int position = 0;

        while (position < c.Count - 1)
        {
            position += position + 2 < c.Count && c[position + 2] == 0 ? 2 : 1;
            jumps++;
        }

        return jumps;
    }
}
