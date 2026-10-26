namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Binary Search Tree: Lowest Common Ancestor — walk down from the root; the first node whose
/// value lies between v1 and v2 (inclusive) is where their paths split. O(height).
/// https://www.hackerrank.com/challenges/binary-search-tree-lowest-common-ancestor
/// </summary>
public static class BstLowestCommonAncestor
{
    public static Node Solve(Node root, int v1, int v2)
    {
        var current = root;

        while (true)
        {
            if (v1 < current.Data && v2 < current.Data)
            {
                current = current.Left!;
            }
            else if (v1 > current.Data && v2 > current.Data)
            {
                current = current.Right!;
            }
            else
            {
                return current;
            }
        }
    }
}
