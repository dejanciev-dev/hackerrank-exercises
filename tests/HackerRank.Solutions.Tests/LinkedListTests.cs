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
}
