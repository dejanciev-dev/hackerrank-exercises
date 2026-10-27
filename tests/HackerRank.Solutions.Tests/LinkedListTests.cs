using HackerRank.Solutions.DataStructures;

namespace HackerRank.Solutions.Tests;

public class LinkedListTests
{
    [Fact]
    public void ReverseLinkedList_ReversesNodes() =>
        Assert.Equal([5, 4, 3, 2, 1], Build.ToArray(ReverseLinkedList.Solve(Build.List(1, 2, 3, 4, 5))));

    [Fact]
    public void ReverseLinkedList_HandlesEmptyList() =>
        Assert.Null(ReverseLinkedList.Solve(null));

    [Fact]
    public void MergeTwoSortedLists_Merges()
    {
        Assert.Equal([1, 2, 3, 3, 4], Build.ToArray(MergeTwoSortedLists.Solve(Build.List(1, 2, 3), Build.List(3, 4))));
        Assert.Equal([1, 1, 2, 3, 7], Build.ToArray(MergeTwoSortedLists.Solve(Build.List(1, 3, 7), Build.List(1, 2))));
    }

    [Fact]
    public void MergeTwoSortedLists_HandlesEmptyInput() =>
        Assert.Equal([1, 2], Build.ToArray(MergeTwoSortedLists.Solve(null, Build.List(1, 2))));

    [Fact]
    public void FindMergePoint_SameLengthPrefixes()
    {
        var shared = Build.List(3);
        var head1 = Build.ListWithTail(shared, 1, 2)!;
        var head2 = Build.ListWithTail(shared, 1)!;

        Assert.Equal(3, FindMergePoint.Solve(head1, head2));
    }

    [Fact]
    public void FindMergePoint_DifferentLengthPrefixes()
    {
        var shared = Build.List(7, 8);
        var head1 = Build.ListWithTail(shared, 1, 2, 3, 4)!;
        var head2 = Build.ListWithTail(shared, 9)!;

        Assert.Equal(7, FindMergePoint.Solve(head1, head2));
    }

    [Fact]
    public void CycleDetection_FindsCycle()
    {
        var head = Build.List(1, 2, 3)!;
        head.Next!.Next!.Next = head.Next; // 3 -> 2

        Assert.True(CycleDetection.Solve(head));
    }

    [Fact]
    public void CycleDetection_FindsSelfLoop()
    {
        var head = new SinglyLinkedListNode(1);
        head.Next = head;

        Assert.True(CycleDetection.Solve(head));
    }

    [Fact]
    public void CycleDetection_AcyclicLists()
    {
        Assert.False(CycleDetection.Solve(Build.List(1, 2, 3)));
        Assert.False(CycleDetection.Solve(null));
    }

    [Theory]
    [InlineData(new[] { 16, 13, 7 }, 1, 2, new[] { 16, 13, 1, 7 })]
    [InlineData(new[] { 16, 13, 7 }, 1, 0, new[] { 1, 16, 13, 7 })]
    [InlineData(new[] { 16, 13, 7 }, 1, 3, new[] { 16, 13, 7, 1 })]
    [InlineData(new int[0], 5, 0, new[] { 5 })]
    public void InsertNodeAtPosition_Samples(int[] values, int data, int position, int[] expected) =>
        Assert.Equal(expected, Build.ToArray(InsertNodeAtPosition.Solve(Build.List(values), data, position)));

    [Theory]
    [InlineData(new[] { 1, 2, 2, 3, 3, 3, 3 }, new[] { 1, 2, 3 })]
    [InlineData(new[] { 3, 3, 3, 4, 5, 5 }, new[] { 3, 4, 5 })]
    [InlineData(new[] { 1 }, new[] { 1 })]
    public void DeleteDuplicateValueNodes_Samples(int[] values, int[] expected) =>
        Assert.Equal(expected, Build.ToArray(DeleteDuplicateValueNodes.Solve(Build.List(values))));

    [Theory]
    [InlineData(new[] { 3, 2, 1 }, 2, 3)]
    [InlineData(new[] { 3, 2, 1 }, 0, 1)]
    [InlineData(new[] { 1 }, 0, 1)]
    public void GetNodeValue_Samples(int[] values, int positionFromTail, int expected) =>
        Assert.Equal(expected, GetNodeValue.Solve(Build.List(values)!, positionFromTail));

    [Theory]
    [InlineData(new[] { 1, 2 }, new[] { 1 }, false)]
    [InlineData(new[] { 1, 2 }, new[] { 1, 2 }, true)]
    [InlineData(new[] { 1, 2 }, new[] { 1, 3 }, false)]
    [InlineData(new int[0], new int[0], true)]
    public void CompareTwoLinkedLists_Samples(int[] first, int[] second, bool expected) =>
        Assert.Equal(expected, CompareTwoLinkedLists.Solve(Build.List(first), Build.List(second)));

    [Theory]
    [InlineData(new[] { 20, 6, 2, 19, 7, 4, 15, 9 }, 3, new[] { 20, 6, 2, 7, 4, 15, 9 })]
    [InlineData(new[] { 1, 2, 3 }, 0, new[] { 2, 3 })]
    [InlineData(new[] { 1, 2, 3 }, 2, new[] { 1, 2 })]
    public void DeleteNode_Samples(int[] values, int position, int[] expected) =>
        Assert.Equal(expected, Build.ToArray(DeleteNode.Solve(Build.List(values)!, position)));

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, new[] { 4, 3, 2, 1 })]
    [InlineData(new[] { 7 }, new[] { 7 })]
    [InlineData(new int[0], new int[0])]
    public void ReverseDoublyLinkedList_ReversesBothLinks(int[] values, int[] expected) =>
        Assert.Equal(expected, Build.ToArray(ReverseDoublyLinkedList.Solve(Build.DoublyList(values))));

    [Theory]
    [InlineData(new[] { 1, 3, 4, 10 }, 5, new[] { 1, 3, 4, 5, 10 })]
    [InlineData(new[] { 2, 3, 4 }, 1, new[] { 1, 2, 3, 4 })]
    [InlineData(new[] { 1, 2, 3 }, 9, new[] { 1, 2, 3, 9 })]
    [InlineData(new[] { 1, 2, 2 }, 2, new[] { 1, 2, 2, 2 })]
    [InlineData(new int[0], 4, new[] { 4 })]
    public void SortedInsertDoublyLinkedList_KeepsOrderAndLinks(int[] values, int data, int[] expected) =>
        Assert.Equal(expected, Build.ToArray(SortedInsertDoublyLinkedList.Solve(Build.DoublyList(values), data)));

    [Theory]
    [InlineData(new[] { 141, 302 }, 164, new[] { 141, 302, 164 })]
    [InlineData(new int[0], 7, new[] { 7 })]
    public void InsertNodeAtTail_Appends(int[] values, int data, int[] expected) =>
        Assert.Equal(expected, Build.ToArray(InsertNodeAtTail.Solve(Build.List(values), data)));

    [Theory]
    [InlineData(new[] { 383, 484 }, 392, new[] { 392, 383, 484 })]
    [InlineData(new int[0], 7, new[] { 7 })]
    public void InsertNodeAtHead_Prepends(int[] values, int data, int[] expected) =>
        Assert.Equal(expected, Build.ToArray(InsertNodeAtHead.Solve(Build.List(values), data)));
}
