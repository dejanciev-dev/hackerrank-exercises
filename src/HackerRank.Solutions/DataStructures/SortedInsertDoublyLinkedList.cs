namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Inserting a Node Into a Sorted Doubly Linked List — insert <c>data</c> so the list stays
/// sorted, fixing both the Next and Prev links, and return the (possibly new) head.
/// https://www.hackerrank.com/challenges/insert-a-node-into-a-sorted-doubly-linked-list
/// </summary>
public static class SortedInsertDoublyLinkedList
{
    public static DoublyLinkedListNode Solve(DoublyLinkedListNode? llist, int data)
    {
        var inserted = new DoublyLinkedListNode(data);

        if (llist is null || data <= llist.Data)
        {
            inserted.Next = llist;
            if (llist is not null)
            {
                llist.Prev = inserted;
            }

            return inserted;
        }

        var previous = llist;
        while (previous.Next is not null && previous.Next.Data < data)
        {
            previous = previous.Next;
        }

        inserted.Next = previous.Next;
        inserted.Prev = previous;
        if (previous.Next is not null)
        {
            previous.Next.Prev = inserted;
        }

        previous.Next = inserted;
        return llist;
    }
}
