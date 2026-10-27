namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Delete a Node — remove the node at a zero-based position and return the head, which
/// changes when the position is 0.
/// https://www.hackerrank.com/challenges/delete-a-node-from-a-linked-list
/// </summary>
public static class DeleteNode
{
    public static SinglyLinkedListNode? Solve(SinglyLinkedListNode head, int position)
    {
        if (position == 0)
        {
            return head.Next;
        }

        var previous = head;
        for (int i = 1; i < position; i++)
        {
            previous = previous.Next!;
        }

        previous.Next = previous.Next?.Next;
        return head;
    }
}
