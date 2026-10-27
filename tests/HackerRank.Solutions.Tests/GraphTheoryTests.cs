using HackerRank.Solutions.GraphTheory;

namespace HackerRank.Solutions.Tests;

public class GraphTheoryTests
{
    [Fact]
    public void BfsShortestReach_Samples()
    {
        Assert.Equal([6, 6, -1], BfsShortestReach.Solve(4, [[1, 2], [1, 3]], 1));
        Assert.Equal([-1, 6], BfsShortestReach.Solve(3, [[2, 3]], 2));
    }

    [Fact]
    public void BfsShortestReach_CountsHops() =>
        Assert.Equal([6, 12, 18], BfsShortestReach.Solve(4, [[1, 2], [2, 3], [3, 4]], 1));

    [Fact]
    public void RoadsAndLibraries_Samples()
    {
        Assert.Equal(4L, RoadsAndLibraries.Solve(3, 2, 1, [[1, 2], [3, 1], [2, 3]]));
        Assert.Equal(12L, RoadsAndLibraries.Solve(6, 2, 5, [[1, 3], [3, 4], [2, 4], [1, 2], [2, 3], [5, 6]]));
    }

    [Fact]
    public void RoadsAndLibraries_CountsIsolatedCities() =>
        // Components {1, 2, 3}, {4}, {5}: three libraries plus two roads.
        Assert.Equal(11L, RoadsAndLibraries.Solve(5, 3, 1, [[1, 2], [2, 3]]));

    [Fact]
    public void JourneyToTheMoon_Samples()
    {
        Assert.Equal(6L, JourneyToTheMoon.Solve(5, [[0, 1], [2, 3], [0, 4]]));
        Assert.Equal(5L, JourneyToTheMoon.Solve(4, [[0, 2]]));
    }

    [Fact]
    public void JourneyToTheMoon_DoesNotOverflow() =>
        Assert.Equal(4_999_950_000L, JourneyToTheMoon.Solve(100_000, []));

    [Fact]
    public void EvenTree_Sample() =>
        Assert.Equal(2, EvenTree.Solve(10, [[2, 1], [3, 1], [4, 3], [5, 2], [6, 1], [7, 2], [8, 6], [9, 8], [10, 8]]));

    [Fact]
    public void KruskalMst_Sample() =>
        Assert.Equal(12, KruskalMst.Solve(4, [[1, 2, 5], [1, 3, 3], [4, 1, 6], [2, 4, 7], [3, 2, 4], [3, 4, 5]]));

    [Fact]
    public void PrimsMst_Sample() =>
        Assert.Equal(15, PrimsMst.Solve(5, [[1, 2, 3], [1, 3, 4], [4, 2, 6], [5, 2, 2], [2, 3, 5], [3, 5, 7]], 1));

    [Fact]
    public void MstAlgorithms_Agree()
    {
        int[][] edges = [[1, 2, 20], [1, 3, 50], [1, 4, 70], [1, 5, 90], [2, 3, 30], [3, 4, 40], [4, 5, 60]];

        Assert.Equal(150, KruskalMst.Solve(5, edges));
        Assert.Equal(150, PrimsMst.Solve(5, edges, 3));
    }

    [Fact]
    public void DijkstraShortestReach_Samples()
    {
        Assert.Equal([24L, 3L, 15L], DijkstraShortestReach.Solve(4, [[1, 2, 24], [1, 4, 20], [3, 1, 3], [4, 3, 12]], 1));
        Assert.Equal([10L, 16L, 8L, -1L], DijkstraShortestReach.Solve(5, [[1, 2, 10], [1, 3, 6], [2, 4, 8]], 2));
    }

    [Fact]
    public void DijkstraShortestReach_UsesCheapestParallelEdge() =>
        Assert.Equal([2L], DijkstraShortestReach.Solve(2, [[1, 2, 9], [1, 2, 2], [2, 1, 5]], 1));

    [Fact]
    public void SnakesAndLadders_Samples()
    {
        Assert.Equal(3, SnakesAndLadders.Solve(
            [[32, 62], [42, 68], [12, 98]],
            [[95, 13], [97, 25], [93, 37], [79, 27], [75, 19], [49, 47], [67, 17]]));

        Assert.Equal(5, SnakesAndLadders.Solve(
            [[8, 52], [6, 80], [26, 42], [2, 72]],
            [[51, 19], [39, 11], [37, 29], [81, 3], [59, 5], [79, 23], [53, 7], [43, 33], [77, 21]]));
    }

    [Fact]
    public void SnakesAndLadders_ReportsUnreachable() =>
        Assert.Equal(-1, SnakesAndLadders.Solve([], [[94, 1], [95, 1], [96, 1], [97, 1], [98, 1], [99, 1]]));

    [Fact]
    public void ComponentsInAGraph_Sample() =>
        Assert.Equal([2, 4], ComponentsInAGraph.Solve([[1, 6], [2, 7], [3, 8], [4, 9], [2, 6]]));
}
