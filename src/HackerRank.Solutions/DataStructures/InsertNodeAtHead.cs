namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Insert a node at the head of a linked list — the new node points at the old head and
/// becomes the head. O(1).
/// https://www.hackerrank.com/challenges/insert-a-node-at-the-head-of-a-linked-list
/// </summary>
public static class InsertNodeAtHead
{
    public static SinglyLinkedListNode Solve(SinglyLinkedListNode? head, int data) =>
        new(data) { Next = head };
}
