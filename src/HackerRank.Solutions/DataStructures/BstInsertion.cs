namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Binary Search Tree: Insertion — insert a value into a BST and return the root.
/// Iterative, so deep (degenerate) trees can't overflow the call stack.
/// https://www.hackerrank.com/challenges/binary-search-tree-insertion
/// </summary>
public static class BstInsertion
{
    public static Node Solve(Node? root, int data)
    {
        var node = new Node(data);
        if (root is null)
        {
            return node;
        }

        var current = root;
        while (true)
        {
            if (data < current.Data)
            {
                if (current.Left is null)
                {
                    current.Left = node;
                    return root;
                }

                current = current.Left;
            }
            else
            {
                if (current.Right is null)
                {
                    current.Right = node;
                    return root;
                }

                current = current.Right;
            }
        }
    }
}
