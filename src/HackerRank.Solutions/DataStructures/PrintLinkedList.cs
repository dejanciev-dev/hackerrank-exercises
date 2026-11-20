namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Print the Elements of a Linked List — report the data of every node from head to tail.
/// An empty list reports nothing. O(n).
/// https://www.hackerrank.com/challenges/print-the-elements-of-a-linked-list
/// </summary>
public static class PrintLinkedList
{
    public static int[] Solve(SinglyLinkedListNode? head)
    {
        var values = new List<int>();
        for (var node = head; node is not null; node = node.Next)
        {
            values.Add(node.Data);
        }

        return [.. values];
    }
}
