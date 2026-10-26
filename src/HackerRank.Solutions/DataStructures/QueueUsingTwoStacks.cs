namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Queue using Two Stacks — handle "1 x" (enqueue), "2" (dequeue) and "3" (print front)
/// using only stacks. Elements move from the inbox to the outbox lazily, so each operation is
/// amortized O(1). Returns the printed values.
/// https://www.hackerrank.com/challenges/queue-using-two-stacks
/// </summary>
public static class QueueUsingTwoStacks
{
    public static int[] Solve(IReadOnlyList<string> queries)
    {
        var inbox = new Stack<int>();
        var outbox = new Stack<int>();
        var printed = new List<int>();

        foreach (var query in queries)
        {
            var parts = query.Split(' ');

            if (parts[0] == "1")
            {
                inbox.Push(int.Parse(parts[1]));
                continue;
            }

            if (outbox.Count == 0)
            {
                while (inbox.Count > 0)
                {
                    outbox.Push(inbox.Pop());
                }
            }

            if (parts[0] == "2")
            {
                outbox.Pop();
            }
            else
            {
                printed.Add(outbox.Peek());
            }
        }

        return printed.ToArray();
    }
}
