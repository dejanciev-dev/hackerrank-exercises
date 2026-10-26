namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Reverse a linked list — re-point every node at its predecessor in a single O(n) pass.
/// https://www.hackerrank.com/challenges/reverse-a-linked-list
/// </summary>
public static class ReverseLinkedList
{
    public static SinglyLinkedListNode? Solve(SinglyLinkedListNode? head)
    {
        SinglyLinkedListNode? previous = null;

        while (head is not null)
        {
            var next = head.Next;
            head.Next = previous;
            previous = head;
            head = next;
        }

        return previous;
    }
}
