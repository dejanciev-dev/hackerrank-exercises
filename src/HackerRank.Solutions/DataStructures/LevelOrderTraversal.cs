namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Tree: Level Order Traversal — visit nodes level by level, left to right (breadth-first search).
/// https://www.hackerrank.com/challenges/tree-level-order-traversal
/// </summary>
public static class LevelOrderTraversal
{
    public static int[] Solve(Node? root)
    {
        var visited = new List<int>();
        if (root is null)
        {
            return [];
        }

        var queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            visited.Add(node.Data);

            if (node.Left is not null) queue.Enqueue(node.Left);
            if (node.Right is not null) queue.Enqueue(node.Right);
        }

        return visited.ToArray();
    }
}
