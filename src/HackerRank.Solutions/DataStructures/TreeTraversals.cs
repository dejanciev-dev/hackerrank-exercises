namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Tree: Preorder, Inorder and Postorder Traversal — three HackerRank challenges that share one
/// recursive walk and differ only in when the current node is visited.
/// https://www.hackerrank.com/challenges/tree-preorder-traversal
/// https://www.hackerrank.com/challenges/tree-inorder-traversal
/// https://www.hackerrank.com/challenges/tree-postorder-traversal
/// </summary>
public static class TreeTraversals
{
    public static int[] Preorder(Node? root)
    {
        var visited = new List<int>();
        Walk(root, visited, pre: true, post: false);
        return visited.ToArray();
    }

    public static int[] Inorder(Node? root)
    {
        var visited = new List<int>();
        Walk(root, visited, pre: false, post: false);
        return visited.ToArray();
    }

    public static int[] Postorder(Node? root)
    {
        var visited = new List<int>();
        Walk(root, visited, pre: false, post: true);
        return visited.ToArray();
    }

    private static void Walk(Node? node, List<int> visited, bool pre, bool post)
    {
        if (node is null)
        {
            return;
        }

        if (pre) visited.Add(node.Data);
        Walk(node.Left, visited, pre, post);
        if (!pre && !post) visited.Add(node.Data);
        Walk(node.Right, visited, pre, post);
        if (post) visited.Add(node.Data);
    }
}
