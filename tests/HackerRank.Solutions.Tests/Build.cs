using HackerRank.Solutions.DataStructures;

namespace HackerRank.Solutions.Tests;

/// <summary>
/// Builders and readers for the linked list and tree inputs used by the tests.
/// </summary>
internal static class Build
{
    public static SinglyLinkedListNode? List(params int[] values) => ListWithTail(null, values);

    public static SinglyLinkedListNode? ListWithTail(SinglyLinkedListNode? tail, params int[] values)
    {
        var head = tail;
        for (int i = values.Length - 1; i >= 0; i--)
        {
            head = new SinglyLinkedListNode(values[i]) { Next = head };
        }

        return head;
    }

    public static int[] ToArray(SinglyLinkedListNode? head)
    {
        var values = new List<int>();
        for (; head is not null; head = head.Next)
        {
            values.Add(head.Data);
        }

        return values.ToArray();
    }

    /// <summary>Builds a BST by inserting the values in order, like HackerRank's tree inputs.</summary>
    public static Node Bst(params int[] values)
    {
        Node? root = null;
        foreach (var value in values)
        {
            root = BstInsertion.Solve(root, value);
        }

        return root!;
    }
}
