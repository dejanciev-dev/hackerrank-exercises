namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Compare two linked lists — true when both lists hold the same values in the same order.
/// Walk them together; they match only if they also run out at the same time.
/// https://www.hackerrank.com/challenges/compare-two-linked-lists
/// </summary>
public static class CompareTwoLinkedLists
{
    public static bool Solve(SinglyLinkedListNode? head1, SinglyLinkedListNode? head2)
    {
        for (; head1 is not null && head2 is not null; head1 = head1.Next, head2 = head2.Next)
        {
            if (head1.Data != head2.Data)
            {
                return false;
            }
        }

        return head1 is null && head2 is null;
    }
}
