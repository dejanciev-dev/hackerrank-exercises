namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// The singly linked list node HackerRank's linked list challenges are built on.
/// </summary>
public sealed class SinglyLinkedListNode(int data)
{
    public int Data { get; set; } = data;

    public SinglyLinkedListNode? Next { get; set; }
}
