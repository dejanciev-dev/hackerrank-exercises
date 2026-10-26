namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Delete duplicate-value nodes from a sorted linked list — duplicates are adjacent, so unlink
/// every node equal to its predecessor in one pass.
/// https://www.hackerrank.com/challenges/delete-duplicate-value-nodes-from-a-sorted-linked-list
/// </summary>
public static class DeleteDuplicateValueNodes
{
    public static SinglyLinkedListNode? Solve(SinglyLinkedListNode? head)
    {
        var current = head;

        while (current?.Next is not null)
        {
            if (current.Next.Data == current.Data)
            {
                current.Next = current.Next.Next;
            }
            else
            {
                current = current.Next;
            }
        }

        return head;
    }
}
