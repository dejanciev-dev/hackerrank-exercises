namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Tree: Height of a Binary Tree — the number of edges on the longest root-to-leaf path
/// (a single node has height 0).
/// https://www.hackerrank.com/challenges/tree-height-of-a-binary-tree
/// </summary>
public static class TreeHeight
{
    public static int Solve(Node? root)
    {
        if (root is null)
        {
            return -1;
        }

        return 1 + Math.Max(Solve(root.Left), Solve(root.Right));
    }
}
