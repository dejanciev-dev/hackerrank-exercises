namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Tree: Top View — the nodes seen when looking down on the tree, left to right. Label each
/// node with its horizontal offset from the root; level-order visits higher nodes first, so
/// the first node seen at each offset is the visible one.
/// https://www.hackerrank.com/challenges/tree-top-view
/// </summary>
public static class TopView
{
    public static int[] Solve(Node root)
    {
        var visible = new SortedDictionary<int, int>();
        var queue = new Queue<(Node Node, int Offset)>();
        queue.Enqueue((root, 0));

        while (queue.Count > 0)
        {
            var (node, offset) = queue.Dequeue();
            visible.TryAdd(offset, node.Data);

            if (node.Left is not null)
            {
                queue.Enqueue((node.Left, offset - 1));
            }

            if (node.Right is not null)
            {
                queue.Enqueue((node.Right, offset + 1));
            }
        }

        return visible.Values.ToArray();
    }
}
