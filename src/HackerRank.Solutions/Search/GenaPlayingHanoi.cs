namespace HackerRank.Solutions.Search;

/// <summary>
/// Gena Playing Hanoi — Tower of Hanoi with four rods and discs in any valid starting layout;
/// fewest moves to stack every disc on rod 1. With at most 10 discs there are at most
/// 4^10 ≈ 10^6 states (each disc's rod, in base 4), so a plain BFS works. A rod's top disc is
/// the smallest disc on it.
/// https://www.hackerrank.com/challenges/gena
/// </summary>
public static class GenaPlayingHanoi
{
    /// <param name="posts">posts[i] is the rod (1–4) holding disc i + 1, where disc 1 is the smallest.</param>
    public static int Solve(IReadOnlyList<int> posts)
    {
        int n = posts.Count;
        int start = 0;
        for (int disc = n - 1; disc >= 0; disc--)
        {
            start = start * 4 + (posts[disc] - 1);
        }

        var distance = new int[1 << (2 * n)];
        Array.Fill(distance, -1);
        distance[start] = 0;

        var queue = new Queue<int>();
        queue.Enqueue(start);
        var top = new int[4];

        while (queue.Count > 0)
        {
            int state = queue.Dequeue();
            if (state == 0)
            {
                return distance[0];
            }

            Array.Fill(top, n);
            for (int disc = n - 1; disc >= 0; disc--)
            {
                top[(state >> (2 * disc)) & 3] = disc;
            }

            for (int from = 0; from < 4; from++)
            {
                int disc = top[from];
                if (disc == n)
                {
                    continue;
                }

                for (int to = 0; to < 4; to++)
                {
                    if (to == from || top[to] < disc)
                    {
                        continue;
                    }

                    int next = state & ~(3 << (2 * disc)) | (to << (2 * disc));
                    if (distance[next] == -1)
                    {
                        distance[next] = distance[state] + 1;
                        queue.Enqueue(next);
                    }
                }
            }
        }

        return -1;
    }
}
