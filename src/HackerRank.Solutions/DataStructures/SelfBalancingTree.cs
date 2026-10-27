namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Self Balancing Tree — insert into an AVL tree and rebalance on the way back up. A node
/// whose children's heights differ by 2 is fixed with a single rotation, or a double one
/// when the heavy child leans the other way. O(log n) per insertion.
/// https://www.hackerrank.com/challenges/self-balancing-tree
/// </summary>
public static class SelfBalancingTree
{
    public static AvlNode Insert(AvlNode? root, int value)
    {
        if (root is null)
        {
            return new AvlNode(value);
        }

        if (value < root.Value)
        {
            root.Left = Insert(root.Left, value);
        }
        else
        {
            root.Right = Insert(root.Right, value);
        }

        return Rebalance(root);
    }

    public static int HeightOf(AvlNode? node) => node?.Height ?? -1;

    private static AvlNode Rebalance(AvlNode node)
    {
        Update(node);
        int balance = HeightOf(node.Left) - HeightOf(node.Right);

        if (balance > 1)
        {
            if (HeightOf(node.Left!.Left) < HeightOf(node.Left.Right))
            {
                node.Left = RotateLeft(node.Left);
            }

            return RotateRight(node);
        }

        if (balance < -1)
        {
            if (HeightOf(node.Right!.Right) < HeightOf(node.Right.Left))
            {
                node.Right = RotateRight(node.Right);
            }

            return RotateLeft(node);
        }

        return node;
    }

    private static AvlNode RotateRight(AvlNode node)
    {
        var pivot = node.Left!;
        node.Left = pivot.Right;
        pivot.Right = node;
        Update(node);
        Update(pivot);
        return pivot;
    }

    private static AvlNode RotateLeft(AvlNode node)
    {
        var pivot = node.Right!;
        node.Right = pivot.Left;
        pivot.Left = node;
        Update(node);
        Update(pivot);
        return pivot;
    }

    private static void Update(AvlNode node) =>
        node.Height = 1 + Math.Max(HeightOf(node.Left), HeightOf(node.Right));
}
