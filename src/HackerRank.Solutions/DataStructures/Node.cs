namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// The binary tree node HackerRank's tree challenges are built on.
/// </summary>
public sealed class Node(int data)
{
    public int Data { get; set; } = data;

    public Node? Left { get; set; }

    public Node? Right { get; set; }
}
