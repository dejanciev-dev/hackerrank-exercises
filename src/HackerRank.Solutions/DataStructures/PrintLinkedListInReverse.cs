namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Print the Elements of a Linked List in Reverse — report the data of every node from tail to
/// head without modifying the list. The values are collected in one pass and then read backwards
/// (the explicit stack that recursion would use). O(n) time and space.
/// https://www.hackerrank.com/challenges/print-the-elements-of-a-linked-list-in-reverse
/// </summary>
public static class PrintLinkedListInReverse
{
    public static int[] Solve(SinglyLinkedListNode? head)
    {
        var stack = new Stack<int>();
        for (var node = head; node is not null; node = node.Next)
        {
            stack.Push(node.Data);
        }

        return [.. stack];
    }
}
