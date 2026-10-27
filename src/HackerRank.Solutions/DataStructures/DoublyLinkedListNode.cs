namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// The doubly linked list node HackerRank's doubly linked list challenges are built on.
/// </summary>
public sealed class DoublyLinkedListNode(int data)
{
    public int Data { get; set; } = data;

    public DoublyLinkedListNode? Next { get; set; }

    public DoublyLinkedListNode? Prev { get; set; }
}
