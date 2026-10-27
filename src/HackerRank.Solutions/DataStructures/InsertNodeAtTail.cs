namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Insert a Node at the Tail of a Linked List — walk to the last node and link the new one;
/// an empty list becomes the new node.
/// https://www.hackerrank.com/challenges/insert-a-node-at-the-tail-of-a-linked-list
/// </summary>
public static class InsertNodeAtTail
{
    public static SinglyLinkedListNode Solve(SinglyLinkedListNode? head, int data)
    {
        var inserted = new SinglyLinkedListNode(data);
        if (head is null)
        {
            return inserted;
        }

        var tail = head;
        while (tail.Next is not null)
        {
            tail = tail.Next;
        }

        tail.Next = inserted;
        return head;
    }
}
