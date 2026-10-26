namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Insert a node at a specific position in a linked list (0-based); returns the head.
/// https://www.hackerrank.com/challenges/insert-a-node-at-a-specific-position-in-a-linked-list
/// </summary>
public static class InsertNodeAtPosition
{
    public static SinglyLinkedListNode Solve(SinglyLinkedListNode? head, int data, int position)
    {
        var node = new SinglyLinkedListNode(data);

        if (head is null || position == 0)
        {
            node.Next = head;
            return node;
        }

        var current = head;
        for (int i = 0; i < position - 1 && current.Next is not null; i++)
        {
            current = current.Next;
        }

        node.Next = current.Next;
        current.Next = node;
        return head;
    }
}
