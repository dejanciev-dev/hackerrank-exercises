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

    [Fact]
    public void FloydCityOfBlindingLights_Sample() =>
        Assert.Equal(
            [5, -1, 11],
            FloydCityOfBlindingLights.Solve(4, [[1, 2, 5], [1, 4, 24], [2, 4, 6], [3, 4, 4], [3, 2, 7]], [[1, 2], [3, 1], [1, 4]]));

    [Fact]
    public void FloydCityOfBlindingLights_RepeatedEdgeReplacesEarlierOne() =>
        Assert.Equal([9, 0], FloydCityOfBlindingLights.Solve(2, [[1, 2, 3], [1, 2, 9]], [[1, 2], [2, 2]]));

    [Fact]
    public void JackGoesToRapture_Samples()
    {
        Assert.Equal("80", JackGoesToRapture.Solve(5, [[1, 2, 60], [3, 5, 70], [1, 4, 120], [4, 5, 150], [2, 3, 80]]));
        Assert.Equal("NO PATH EXISTS", JackGoesToRapture.Solve(3, [[1, 2, 5]]));
    }

    [Fact]
    public void RustAndMurderer_Samples()
    {
        Assert.Equal([3, 1, 2], RustAndMurderer.Solve(4, [[1, 2], [2, 3], [1, 4]], 1));
        Assert.Equal([2, 2, 1], RustAndMurderer.Solve(4, [[1, 2], [2, 3]], 2));
        Assert.Equal([-1], RustAndMurderer.Solve(2, [[1, 2]], 1));
    }

    [Fact]
    public void RoadsInHackerland_Sample() =>
        Assert.Equal("1000100", RoadsInHackerland.Solve(5, [[1, 3, 5], [4, 5, 0], [2, 1, 3], [3, 2, 1], [4, 3, 4], [4, 2, 2]]));

    [Fact]
    public void RoadsInHackerland_CarriesIntoHigherBits() =>
        // A path 1-2-3 with weights 1 and 2: distances 1 + 2 + 3 = 6.
        Assert.Equal("110", RoadsInHackerland.Solve(3, [[1, 2, 0], [2, 3, 1]]));

    [Fact]
    public void MinimumPenaltyPath_Samples()
    {
        Assert.Equal(3, MinimumPenaltyPath.Solve(3, [[1, 2, 1], [1, 2, 1000], [2, 3, 3], [1, 3, 100]], 1, 3));
        Assert.Equal(-1, MinimumPenaltyPath.Solve(3, [[1, 2, 1]], 1, 3));
    }

    [Fact]
    public void MinimumPenaltyPath_PrefersSmallerOrOverFewerEdges() =>
        // Direct edge 4 vs. path 1 | 2 = 3.
        Assert.Equal(3, MinimumPenaltyPath.Solve(3, [[1, 3, 4], [1, 2, 1], [2, 3, 2]], 1, 3));

    [Fact]
    public void MatrixMachines_Sample() =>
        Assert.Equal(10L, MatrixMachines.Solve([[2, 1, 8], [1, 0, 5], [2, 4, 5], [1, 3, 4]], [2, 4, 0]));

    [Fact]
    public void FindTheNearestClone_Samples()
    {
        Assert.Equal(1, FindTheNearestClone.Solve(4, [1, 1, 4], [2, 3, 2], [1, 2, 1, 1], 1));
        Assert.Equal(-1, FindTheNearestClone.Solve(4, [1, 1, 4], [2, 3, 2], [1, 2, 3, 4], 2));
        Assert.Equal(3, FindTheNearestClone.Solve(5, [1, 1, 2, 3], [2, 3, 4, 5], [1, 2, 3, 3, 2], 2));
    }

    [Fact]
    public void KingdomConnectivity_Samples()
    {
        Assert.Equal("2", KingdomConnectivity.Solve(5, [[1, 2], [2, 4], [2, 3], [3, 4], [4, 5]]));
        Assert.Equal("INFINITE PATHS", KingdomConnectivity.Solve(5, [[1, 2], [2, 4], [2, 3], [3, 4], [4, 5], [4, 2]]));
    }

    [Fact]
    public void KingdomConnectivity_IgnoresCyclesOffEveryRoute()
    {
        Assert.Equal("1", KingdomConnectivity.Solve(4, [[1, 4], [2, 3], [3, 2]]));
        Assert.Equal("1", KingdomConnectivity.Solve(3, [[1, 3], [3, 2], [2, 2]]));
        Assert.Equal("0", KingdomConnectivity.Solve(3, [[1, 2]]));
        Assert.Equal("2", KingdomConnectivity.Solve(2, [[1, 2], [1, 2]]));
    }

    [Fact]
    public void SynchronousShopping_Sample() =>
        Assert.Equal(30, SynchronousShopping.Solve(
            5, 5, [[1], [2], [3], [4], [5]], [[1, 2, 10], [1, 3, 10], [2, 4, 10], [3, 5, 10], [4, 5, 10]]));

    [Fact]
    public void SynchronousShopping_OneCatCanDoEverything() =>
        Assert.Equal(7, SynchronousShopping.Solve(3, 2, [[], [1, 2], []], [[1, 2, 3], [2, 3, 4], [1, 3, 1]]));

    [Fact]
    public void TheStoryOfATree_Samples()
    {
        int[][] edges = [[1, 2], [1, 3], [3, 4]];
        int[][] guesses = [[1, 2], [3, 4]];

        Assert.Equal("1/2", TheStoryOfATree.Solve(4, edges, guesses, 2));
        Assert.Equal("1/1", TheStoryOfATree.Solve(4, edges, guesses, 1));
        Assert.Equal("0/1", TheStoryOfATree.Solve(4, edges, guesses, 3));
    }

    [Fact]
    public void JeaniesRoute_Sample() =>
        Assert.Equal(6L, JeaniesRoute.Solve(5, [1, 3, 4], [[1, 2, 1], [2, 3, 2], [2, 4, 2], [3, 5, 3]]));

    [Fact]
    public void JeaniesRoute_SingleCityNeedsNoTravel() =>
        Assert.Equal(0L, JeaniesRoute.Solve(3, [2], [[1, 2, 5], [2, 3, 5]]));

    [Theory]
    [InlineData(3, 2L, 2)]
    [InlineData(4, 6L, 4)]
    [InlineData(5, 7L, 3)]
    [InlineData(10_000, 1L, 2)]
    public void Clique_Samples(int n, long m, int expected) =>
        Assert.Equal(expected, Clique.Solve(n, m));

    [Fact]
    public void RealEstateBroker_Sample() =>
        Assert.Equal(2, RealEstateBroker.Solve([[5, 110], [9, 500], [20, 400]], [[10, 100], [2, 200], [30, 300]]));

    [Fact]
    public void RealEstateBroker_NeedsAugmentingPaths() =>
        // Client 0 accepts both houses, client 1 only house 0: both sell only if client 0 takes house 1.
        Assert.Equal(2, RealEstateBroker.Solve([[1, 100], [1, 50]], [[5, 50], [5, 100]]));

    [Theory]
    [InlineData(new[] { 2, 1 }, 2L)]
    [InlineData(new[] { 2, 2 }, 4L)]
    [InlineData(new[] { 4 }, 16L)]
    [InlineData(new[] { 1 }, 1L)]
    [InlineData(new[] { 1, 1, 1 }, 3L)]
    public void BeadOrnaments_Samples(int[] b, long expected) =>
        Assert.Equal(expected, BeadOrnaments.Solve(b));

    [Theory]
    [InlineData(2, new[] { 5, 3, 4 }, 2)]
    [InlineData(1, new[] { 3, 4, 5, 1, 2 }, 1)]
    [InlineData(10, new[] { 1, 2, 3 }, 3)]
    public void ProblemSolving_Samples(int k, int[] v, int expected) =>
        Assert.Equal(expected, ProblemSolving.Solve(k, v));

    [Fact]
    public void DemandingMoney_Sample() =>
        Assert.Equal([8L, 2L], DemandingMoney.Solve([6, 8, 2], [[1, 2], [3, 2]]));

    [Fact]
    public void DemandingMoney_CountsZeroMoneyHousesAsDistinctChoices() =>
        Assert.Equal([5L, 4L], DemandingMoney.Solve([5, 0, 0], []));

    [Fact]
    public void DemandingMoney_MatchesBruteForce()
    {
        var random = new Random(71);
        for (int trial = 0; trial < 60; trial++)
        {
            int n = random.Next(1, 10);
            var money = Enumerable.Range(0, n).Select(_ => random.Next(0, 6)).ToArray();
            var roads = Enumerable.Range(0, random.Next(0, 12))
                .Select(_ => new[] { random.Next(1, n + 1), random.Next(1, n + 1) })
                .Where(r => r[0] != r[1])
                .ToArray();

            long best = -1, ways = 0;
            for (int mask = 0; mask < 1 << n; mask++)
            {
                if (roads.Any(r => (mask & (1 << (r[0] - 1))) != 0 && (mask & (1 << (r[1] - 1))) != 0))
                {
                    continue;
                }

                long total = money.Where((_, i) => (mask & (1 << i)) != 0).Sum();
                if (total > best) { best = total; ways = 1; }
                else if (total == best) { ways++; }
            }

            Assert.Equal([best, ways], DemandingMoney.Solve(money, roads));
        }
    }

    [Fact]
    public void JourneyScheduling_MatchesSimulation()
    {
        var random = new Random(113);
        for (int trial = 0; trial < 40; trial++)
        {
            int n = random.Next(1, 12);
            var roads = Enumerable.Range(2, n - 1).Select(v => new[] { random.Next(1, v), v }).ToArray();
            var journeys = Enumerable.Range(0, 5).Select(_ => new[] { random.Next(1, n + 1), random.Next(1, 5) }).ToArray();

            int[] Bfs(int start)
            {
                var d = Enumerable.Repeat(-1, n + 1).ToArray();
                d[start] = 0;
                var queue = new Queue<int>([start]);
                while (queue.Count > 0)
                {
                    int u = queue.Dequeue();
                    foreach (var r in roads)
                    {
                        int v = r[0] == u ? r[1] : r[1] == u ? r[0] : 0;
                        if (v != 0 && d[v] == -1) { d[v] = d[u] + 1; queue.Enqueue(v); }
                    }
                }

                return d;
            }

            var expected = journeys.Select(j =>
            {
                long total = 0;
                int at = j[0];
                for (int step = 0; step < j[1]; step++)
                {
                    var d = Bfs(at);
                    at = Enumerable.Range(1, n).MaxBy(v => d[v]);
                    total += d[at];
                }

                return total;
            }).ToArray();

            Assert.Equal(expected, JourneyScheduling.Solve(n, roads, journeys));
        }
    }

    [Fact]
    public void HackerCountry_Sample() =>
        Assert.Equal("3/2", HackerCountry.Solve([[0, 1], [2, 0]]));

    [Fact]
    public void HackerCountry_MatchesSimpleCycleSearch()
    {
        var random = new Random(127);
        for (int trial = 0; trial < 40; trial++)
        {
            int n = random.Next(2, 6);
            var tolls = Enumerable.Range(0, n).Select(i => Enumerable.Range(0, n).Select(j => i == j ? 0 : random.Next(1, 20)).ToArray()).ToArray();

            // Every simple cycle, as (total, length); the minimum mean cycle is always simple.
            (long Total, long Length)? best = null;
            void Extend(int start, int at, int visited, long total, int length)
            {
                for (int next = 0; next < n; next++)
                {
                    if (next == at) continue;
                    if (next == start && length >= 1)
                    {
                        (long Total, long Length) cycle = (total + tolls[at][next], length + 1);
                        if (best is not { } b || cycle.Total * b.Length < b.Total * cycle.Length) best = cycle;
                    }
                    else if (next > start && (visited & (1 << next)) == 0)
                    {
                        Extend(start, next, visited | (1 << next), total + tolls[at][next], length + 1);
                    }
                }
            }

            for (int start = 0; start < n; start++)
            {
                Extend(start, start, 1 << start, 0, 0);
            }

            var (cycleTotal, cycleLength) = best!.Value;
            long g = (long)System.Numerics.BigInteger.GreatestCommonDivisor(cycleTotal, cycleLength);
            Assert.Equal($"{cycleTotal / g}/{cycleLength / g}", HackerCountry.Solve(tolls));
        }
    }

    [Fact]
    public void FarVertices_MatchesBruteForce()
    {
        var random = new Random(181);
        for (int trial = 0; trial < 60; trial++)
        {
            int n = random.Next(1, 10);
            int k = random.Next(1, 5);
            var edges = Enumerable.Range(2, n - 1).Select(v => new[] { random.Next(1, v), v }).ToArray();

            var distance = new int[n + 1, n + 1];
            for (int s = 1; s <= n; s++)
            {
                for (int t = 1; t <= n; t++) distance[s, t] = s == t ? 0 : 1000;
            }

            foreach (var e in edges)
            {
                distance[e[0], e[1]] = distance[e[1], e[0]] = 1;
            }

            for (int m = 1; m <= n; m++)
                for (int s = 1; s <= n; s++)
                    for (int t = 1; t <= n; t++)
                        distance[s, t] = Math.Min(distance[s, t], distance[s, m] + distance[m, t]);

            int kept = 0;
            for (int mask = 1; mask < 1 << n; mask++)
            {
                var nodes = Enumerable.Range(1, n).Where(v => (mask & (1 << (v - 1))) != 0).ToArray();
                if (nodes.All(u => nodes.All(v => distance[u, v] <= k)))
                {
                    kept = Math.Max(kept, nodes.Length);
                }
            }

            Assert.Equal(n - kept, FarVertices.Solve(n, k, edges));
        }
    }

    [Fact]
    public void ComputerGame_Sample() =>
        Assert.Equal(3, ComputerGame.Solve([2, 5, 6, 7], [4, 9, 10, 23]));

    [Fact]
    public void Liars_Samples()
    {
        Assert.Equal([1, 2], Liars.Solve(3, [[1, 2, 1], [2, 3, 1]]));
        Assert.Equal(
            [13, 14],
            Liars.Solve(20, [[3, 8, 4], [1, 9, 6], [1, 13, 9], [5, 11, 5], [4, 19, 12], [8, 13, 5], [4, 8, 4], [7, 9, 2], [10, 13, 3], [7, 16, 7], [14, 19, 4]]));
    }

    [Fact]
    public void Liars_MatchesBruteForce()
    {
        var random = new Random(73);
        for (int trial = 0; trial < 60; trial++)
        {
            int n = random.Next(1, 9);
            int truth = random.Next(1 << n); // a hidden liar assignment keeps the clues consistent
            var clues = Enumerable.Range(0, random.Next(1, 5)).Select(_ =>
            {
                int a = random.Next(1, n + 1), b = random.Next(a, n + 1);
                int c = Enumerable.Range(a - 1, b - a + 1).Count(i => (truth & (1 << i)) != 0);
                return new[] { a, b, c };
            }).ToArray();

            var counts = Enumerable.Range(0, 1 << n)
                .Where(mask => clues.All(cl => Enumerable.Range(cl[0] - 1, cl[1] - cl[0] + 1).Count(i => (mask & (1 << i)) != 0) == cl[2]))
                .Select(mask => System.Numerics.BitOperations.PopCount((uint)mask))
                .ToArray();

            Assert.Equal([counts.Min(), counts.Max()], Liars.Solve(n, clues));
        }
    }
}
