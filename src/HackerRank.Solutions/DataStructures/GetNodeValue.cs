namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Get Node Value — the value of the node <c>positionFromTail</c> places before the tail. Move
/// a lead pointer that far ahead, then advance both until the lead reaches the tail. One pass.
/// https://www.hackerrank.com/challenges/get-the-value-of-the-node-at-a-specific-position-from-the-tail
/// </summary>
public static class GetNodeValue
{
    public static int Solve(SinglyLinkedListNode head, int positionFromTail)
    {
        var lead = head;
        for (int i = 0; i < positionFromTail; i++)
        {
            lead = lead.Next!;
        }

        var trail = head;
        while (lead.Next is not null)
        {
            lead = lead.Next;
            trail = trail.Next!;
        }

        return trail.Data;
    }
}
