namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Is This a Binary Search Tree? — every node must be strictly within the bounds set by all of
/// its ancestors, not just greater/less than its direct parent. Duplicates are not allowed.
/// https://www.hackerrank.com/challenges/is-binary-search-tree
/// </summary>
public static class IsBinarySearchTree
{
    public static bool Solve(Node? root) => IsWithin(root, long.MinValue, long.MaxValue);

    private static bool IsWithin(Node? node, long low, long high)
    {
        if (node is null)
        {
            return true;
        }

        if (node.Data <= low || node.Data >= high)
        {
            return false;
        }

        return IsWithin(node.Left, low, node.Data) && IsWithin(node.Right, node.Data, high);
    }
}
