namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Reverse a doubly linked list — swap every node's Next and Prev pointers; the old tail
/// becomes the new head. O(n), in place.
/// https://www.hackerrank.com/challenges/reverse-a-doubly-linked-list
/// </summary>
public static class ReverseDoublyLinkedList
{
    public static DoublyLinkedListNode? Solve(DoublyLinkedListNode? head)
    {
        DoublyLinkedListNode? newHead = null;

        for (var node = head; node is not null; node = node.Prev)
        {
            (node.Next, node.Prev) = (node.Prev, node.Next);
            newHead = node;
        }

        return newHead;
    }
}
