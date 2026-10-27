namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Array and simple queries — "1 i j" moves a[i..j] to the front and "2 i j" moves it to the
/// back; return |a[1] - a[n]| and the final array. An implicit treap (keyed by position)
/// cuts out and re-attaches any range with two splits and two merges, O(log n) expected per
/// query.
/// https://www.hackerrank.com/challenges/array-and-simple-queries
/// </summary>
public static class ArrayAndSimpleQueries
{
    private sealed class Treap(int value, int priority)
    {
        public int Value { get; } = value;

        public int Priority { get; } = priority;

        public int Size { get; set; } = 1;

        public Treap? Left { get; set; }

        public Treap? Right { get; set; }
    }

    /// <param name="a">The array.</param>
    /// <param name="queries">Each query as <c>[type, i, j]</c>, 1-based and inclusive.</param>
    public static (long Difference, int[] Final) Solve(IReadOnlyList<int> a, IReadOnlyList<IReadOnlyList<int>> queries)
    {
        var random = new Random(12345);
        Treap? root = null;
        foreach (var value in a)
        {
            root = Merge(root, new Treap(value, random.Next()));
        }

        foreach (var query in queries)
        {
            var (before, rest) = Split(root, query[1] - 1);
            var (middle, after) = Split(rest, query[2] - query[1] + 1);
            var others = Merge(before, after);
            root = query[0] == 1 ? Merge(middle, others) : Merge(others, middle);
        }

        var final = new List<int>(a.Count);
        Collect(root, final);
        return (Math.Abs((long)final[0] - final[^1]), final.ToArray());
    }

    private static int SizeOf(Treap? node) => node?.Size ?? 0;

    private static void Update(Treap node) => node.Size = 1 + SizeOf(node.Left) + SizeOf(node.Right);

    /// <summary>Splits into the first <paramref name="count"/> elements and the rest.</summary>
    private static (Treap? Left, Treap? Right) Split(Treap? node, int count)
    {
        if (node is null)
        {
            return (null, null);
        }

        if (SizeOf(node.Left) >= count)
        {
            var (left, right) = Split(node.Left, count);
            node.Left = right;
            Update(node);
            return (left, node);
        }
        else
        {
            var (left, right) = Split(node.Right, count - SizeOf(node.Left) - 1);
            node.Right = left;
            Update(node);
            return (node, right);
        }
    }

    private static Treap? Merge(Treap? left, Treap? right)
    {
        if (left is null || right is null)
        {
            return left ?? right;
        }

        if (left.Priority > right.Priority)
        {
            left.Right = Merge(left.Right, right);
            Update(left);
            return left;
        }

        right.Left = Merge(left, right.Left);
        Update(right);
        return right;
    }

    private static void Collect(Treap? node, List<int> output)
    {
        var stack = new Stack<Treap>();
        while (node is not null || stack.Count > 0)
        {
            for (; node is not null; node = node.Left)
            {
                stack.Push(node);
            }

            node = stack.Pop();
            output.Add(node.Value);
            node = node.Right;
        }
    }
}
