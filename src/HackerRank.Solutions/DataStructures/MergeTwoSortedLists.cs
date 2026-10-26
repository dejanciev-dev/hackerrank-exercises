namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Merge two sorted linked lists — splice the nodes into one sorted list without allocating
/// new ones, using a dummy head to simplify the edge cases.
/// https://www.hackerrank.com/challenges/merge-two-sorted-linked-lists
/// </summary>
public static class MergeTwoSortedLists
{
    public static SinglyLinkedListNode? Solve(SinglyLinkedListNode? head1, SinglyLinkedListNode? head2)
    {
        var dummy = new SinglyLinkedListNode(0);
        var tail = dummy;

        while (head1 is not null && head2 is not null)
        {
            if (head1.Data <= head2.Data)
            {
                tail.Next = head1;
                head1 = head1.Next;
            }
            else
            {
                tail.Next = head2;
                head2 = head2.Next;
            }

            tail = tail.Next;
        }

        tail.Next = head1 ?? head2;
        return dummy.Next;
    }
}
