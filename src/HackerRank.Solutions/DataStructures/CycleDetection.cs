namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Cycle Detection — does the linked list contain a cycle? Floyd's tortoise and hare: a fast
/// pointer moving two steps eventually laps a slow one if and only if there is a loop.
/// https://www.hackerrank.com/challenges/detect-whether-a-linked-list-contains-a-cycle
/// </summary>
public static class CycleDetection
{
    public static bool Solve(SinglyLinkedListNode? head)
    {
        var slow = head;
        var fast = head;

        while (fast?.Next is not null)
        {
            slow = slow!.Next;
            fast = fast.Next.Next;

            if (slow == fast)
            {
                return true;
            }
        }

        return false;
    }
}
