namespace HackerRank.Solutions.GraphTheory;

/// <summary>
/// Snakes and Ladders: The Quickest Way Up — fewest die rolls (1–6) to get from square 1 to
/// 100, following any snake or ladder you land on; -1 if 100 can't be reached. BFS over the
/// 100 squares.
/// https://www.hackerrank.com/challenges/the-quickest-way-up
/// </summary>
public static class SnakesAndLadders
{
    private const int Goal = 100;

    public static int Solve(IReadOnlyList<IReadOnlyList<int>> ladders, IReadOnlyList<IReadOnlyList<int>> snakes)
    {
        var jump = new int[Goal + 1];
        for (int i = 1; i <= Goal; i++)
        {
            jump[i] = i;
        }

        foreach (var pair in ladders.Concat(snakes))
        {
            jump[pair[0]] = pair[1];
        }

        var rolls = new int[Goal + 1];
        Array.Fill(rolls, -1);
        rolls[1] = 0;

        var queue = new Queue<int>();
        queue.Enqueue(1);

        while (queue.Count > 0)
        {
            int square = queue.Dequeue();

            for (int die = 1; die <= 6 && square + die <= Goal; die++)
            {
                int next = jump[square + die];
                if (rolls[next] == -1)
                {
                    rolls[next] = rolls[square] + 1;
                    queue.Enqueue(next);
                }
            }
        }

        return rolls[Goal];
    }
}
