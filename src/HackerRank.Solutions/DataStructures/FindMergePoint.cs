namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Find Merge Point of Two Lists — return the data of the node where two lists converge.
/// Each pointer walks its own list and then the other one; both cover the same total
/// distance, so they meet exactly at the merge point. O(n + m) time, O(1) memory.
/// https://www.hackerrank.com/challenges/find-the-merge-point-of-two-joined-linked-lists
/// </summary>
public static class FindMergePoint
{
    public static int Solve(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
    {
        var a = head1;
        var b = head2;

        while (a != b)
        {
            a = a!.Next ?? head2;
            b = b!.Next ?? head1;
        }

        return a!.Data;
    }
}
