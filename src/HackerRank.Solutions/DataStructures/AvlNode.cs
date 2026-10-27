namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// An AVL tree node; a leaf has height 0, as in HackerRank's version.
/// </summary>
public sealed class AvlNode(int value)
{
    public int Value { get; set; } = value;

    public int Height { get; set; }

    public AvlNode? Left { get; set; }

    public AvlNode? Right { get; set; }
}
