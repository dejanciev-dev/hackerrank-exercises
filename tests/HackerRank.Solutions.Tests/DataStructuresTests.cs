using HackerRank.Solutions.DataStructures;

namespace HackerRank.Solutions.Tests;

public class DataStructuresTests
{
    [Fact]
    public void ArraysDS_ReversesArray() =>
        Assert.Equal([2, 3, 4, 1], ArraysDS.Solve([1, 4, 3, 2]));

    [Fact]
    public void HourglassSum_FindsMaximum()
    {
        int[][] grid =
        [
            [1, 1, 1, 0, 0, 0],
            [0, 1, 0, 0, 0, 0],
            [1, 1, 1, 0, 0, 0],
            [0, 0, 2, 4, 4, 0],
            [0, 0, 0, 2, 0, 0],
            [0, 0, 1, 2, 4, 0],
        ];

        Assert.Equal(19, HourglassSum.Solve(grid));
    }

    [Fact]
    public void HourglassSum_HandlesAllNegativeValues()
    {
        int[][] grid =
        [
            [-1, -1, 0, -9, -2, -2],
            [-2, -1, -6, -8, -2, -5],
            [-1, -1, -1, -2, -3, -4],
            [-1, -9, -2, -4, -4, -5],
            [-7, -3, -3, -2, -9, -9],
            [-1, -3, -1, -2, -4, -5],
        ];

        Assert.Equal(-6, HourglassSum.Solve(grid));
    }

    [Theory]
    [InlineData(4, new[] { 1, 2, 3, 4, 5 }, new[] { 5, 1, 2, 3, 4 })]
    [InlineData(2, new[] { 1, 2, 3, 4, 5 }, new[] { 3, 4, 5, 1, 2 })]
    public void LeftRotation_Samples(int d, int[] arr, int[] expected) =>
        Assert.Equal(expected, LeftRotation.Solve(d, arr));

    [Fact]
    public void SparseArrays_CountsQueries() =>
        Assert.Equal([2, 1, 0], SparseArrays.Solve(["ab", "ab", "abc"], ["ab", "abc", "bc"]));

    [Theory]
    [InlineData("{[()]}", "YES")]
    [InlineData("{[(])}", "NO")]
    [InlineData("{{[[(())]]}}", "YES")]
    [InlineData("((", "NO")]
    [InlineData("}", "NO")]
    public void BalancedBrackets_Samples(string s, string expected) =>
        Assert.Equal(expected, BalancedBrackets.Solve(s));

    [Fact]
    public void DynamicArray_ReturnsLastAnswers()
    {
        int[][] queries = [[1, 0, 5], [1, 1, 7], [1, 0, 3], [2, 1, 0], [2, 1, 1]];
        Assert.Equal([7, 3], DynamicArray.Solve(2, queries));
    }

    [Fact]
    public void QueueUsingTwoStacks_PrintsFront() =>
        Assert.Equal(
            [14, 14],
            QueueUsingTwoStacks.Solve(["1 42", "2", "1 14", "3", "1 28", "3", "1 60", "1 78", "2", "2"]));

    [Fact]
    public void MaximumElement_TracksMaximum() =>
        Assert.Equal(
            [26, 91],
            MaximumElement.Solve(["1 97", "2", "1 20", "2", "1 26", "1 20", "2", "3", "1 91", "3"]));

    [Fact]
    public void EqualStacks_FindsCommonHeight() =>
        Assert.Equal(5, EqualStacks.Solve([3, 2, 1, 1, 1], [4, 3, 2], [1, 1, 4, 1]));

    [Fact]
    public void EqualStacks_CanEmptyAllStacks() =>
        Assert.Equal(0, EqualStacks.Solve([1], [2], [3]));

    [Theory]
    [InlineData(10L, new[] { 4, 2, 4, 6, 1 }, new[] { 2, 1, 8, 5 }, 4)]
    [InlineData(10L, new[] { 1, 2, 3, 4, 5 }, new[] { 6, 7, 8, 9 }, 4)]
    [InlineData(1L, new[] { 5 }, new[] { 5 }, 0)]
    public void GameOfTwoStacks_Samples(long maxSum, int[] a, int[] b, int expected) =>
        Assert.Equal(expected, GameOfTwoStacks.Solve(maxSum, a, b));

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 9L)]
    [InlineData(new[] { 3, 2, 3 }, 6L)]
    [InlineData(new[] { 1, 3, 5, 9, 11 }, 18L)]
    [InlineData(new[] { 11, 11, 10, 10, 10 }, 50L)]
    public void LargestRectangle_Samples(int[] h, long expected) =>
        Assert.Equal(expected, LargestRectangle.Solve(h));

    [Fact]
    public void SimpleTextEditor_SupportsUndo() =>
        Assert.Equal(
            ["c", "y", "a"],
            SimpleTextEditor.Solve(["1 abc", "3 3", "2 3", "1 xy", "3 2", "4", "4", "3 1"]));

    [Theory]
    [InlineData(7L, new[] { 1, 2, 3, 9, 10, 12 }, 2)]
    [InlineData(9L, new[] { 2, 7, 3, 6, 4, 6 }, 4)]
    [InlineData(10L, new[] { 1, 1 }, -1)]
    [InlineData(1L, new[] { 5, 6 }, 0)]
    public void JesseAndCookies_Samples(long k, int[] a, int expected) =>
        Assert.Equal(expected, JesseAndCookies.Solve(k, a));

    [Fact]
    public void Qheap1_PrintsMinimum() =>
        Assert.Equal([4, 9], Qheap1.Solve(["1 4", "1 9", "3", "2 4", "3"]));

    [Fact]
    public void TruckTour_FindsStartingPump()
    {
        int[][] pumps = [[1, 5], [10, 3], [3, 4]];
        Assert.Equal(1, TruckTour.Solve(pumps));
    }

    [Fact]
    public void Contacts_CountsPrefixMatches() =>
        Assert.Equal([2, 0], Contacts.Solve(["add hack", "add hackerrank", "find hac", "find hak"]));

    [Fact]
    public void ArrayManipulation_Samples()
    {
        int[][] first = [[1, 2, 100], [2, 5, 100], [3, 4, 100]];
        Assert.Equal(200L, ArrayManipulation.Solve(5, first));

        int[][] second = [[1, 5, 3], [4, 8, 7], [6, 9, 1]];
        Assert.Equal(10L, ArrayManipulation.Solve(10, second));

        int[][] third = [[2, 6, 8], [3, 5, 7], [1, 8, 1], [5, 9, 15]];
        Assert.Equal(31L, ArrayManipulation.Solve(10, third));
    }

    [Theory]
    [InlineData(new[] { 6, 5, 8, 4, 7, 10, 9 }, 2)]
    [InlineData(new[] { 3, 6, 2, 7, 5 }, 2)]
    [InlineData(new[] { 4, 3, 7, 5, 6, 4, 2 }, 3)]
    [InlineData(new[] { 5, 4, 3 }, 0)]
    public void PoisonousPlants_Samples(int[] p, int expected) =>
        Assert.Equal(expected, PoisonousPlants.Solve(p));

    [Theory]
    [InlineData(new[] { 3, 4, 7, 6, 5 }, 1, new[] { 4, 6, 3, 7, 5 })]
    [InlineData(new[] { 3, 3, 4, 4, 9 }, 2, new[] { 4, 4, 9, 3, 3 })]
    [InlineData(new[] { 2, 3, 4, 5, 6, 7 }, 3, new[] { 2, 4, 6, 3, 5, 7 })]
    public void Waiter_Samples(int[] number, int q, int[] expected) =>
        Assert.Equal(expected, Waiter.Solve(number, q));

    [Theory]
    [InlineData(new[] { 9, 6, 3, 5, 2 }, 15)]
    [InlineData(new[] { 1, 2 }, 3)]
    public void AndXorOr_Samples(int[] a, int expected) =>
        Assert.Equal(expected, AndXorOr.Solve(a));

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 3)]
    public void DownToZeroII_Samples(int n, int expected) =>
        Assert.Equal(expected, DownToZeroII.Solve(n));

    [Fact]
    public void CastleOnTheGrid_Samples()
    {
        Assert.Equal(3, CastleOnTheGrid.Solve([".X.", ".X.", "..."], 0, 0, 0, 2));
        Assert.Equal(2, CastleOnTheGrid.Solve(["...", ".X.", "..."], 0, 0, 1, 2));
        Assert.Equal(0, CastleOnTheGrid.Solve(["."], 0, 0, 0, 0));
    }

    [Fact]
    public void SwapNodes_Samples()
    {
        Assert.Equal([[3, 1, 2], [2, 1, 3]], SwapNodes.Solve([[2, 3], [-1, -1], [-1, -1]], [1, 1]));
        Assert.Equal([[4, 2, 1, 5, 3]], SwapNodes.Solve([[2, 3], [-1, 4], [-1, 5], [-1, -1], [-1, -1]], [2]));
    }

    [Fact]
    public void FindTheRunningMedian_Sample() =>
        Assert.Equal([12.0, 8.0, 5.0, 4.5, 5.0, 6.0], FindTheRunningMedian.Solve([12, 4, 5, 3, 8, 7]));

    [Fact]
    public void MinimumAverageWaitingTime_Samples()
    {
        Assert.Equal(9L, MinimumAverageWaitingTime.Solve([[0, 3], [1, 9], [2, 6]]));
        Assert.Equal(8L, MinimumAverageWaitingTime.Solve([[0, 3], [1, 9], [2, 5]]));
    }

    [Fact]
    public void MinimumAverageWaitingTime_WaitsForLateArrival() =>
        Assert.Equal(2L, MinimumAverageWaitingTime.Solve([[10, 2], [0, 2]]));

    [Fact]
    public void NoPrefixSet_Samples()
    {
        Assert.Equal(["BAD SET", "aabcde"], NoPrefixSet.Solve(["aab", "defgab", "abcde", "aabcde", "bbbbbbbbbb", "jabjjjad"]));
        Assert.Equal(["BAD SET", "aacghgh"], NoPrefixSet.Solve(["aab", "aac", "aacghgh", "aabghgh"]));
        Assert.Equal(["GOOD SET"], NoPrefixSet.Solve(["aab", "aac", "b"]));
    }

    [Fact]
    public void NoPrefixSet_FlagsWordThatIsPrefixOfEarlierOne() =>
        Assert.Equal(["BAD SET", "ab"], NoPrefixSet.Solve(["abc", "ab"]));

    [Theory]
    [InlineData(new[] { 3, 2, 1, 2, 3, 3 }, 8L)]
    [InlineData(new[] { 1, 1000, 1 }, 0L)]
    [InlineData(new[] { 5, 5, 5 }, 6L)]
    public void JimAndTheSkyscrapers_Samples(int[] arr, long expected) =>
        Assert.Equal(expected, JimAndTheSkyscrapers.Solve(arr));

    [Fact]
    public void QueriesWithFixedLength_Sample() =>
        Assert.Equal([11, 33, 44, 44, 55], QueriesWithFixedLength.Solve([33, 11, 44, 11, 55], [1, 2, 3, 4, 5]));

    [Fact]
    public void QueriesWithFixedLength_MatchesBruteForce()
    {
        int[] arr = [5, 1, 9, 3, 3, 8, 2, 7, 6, 4, 10, 0];
        var queries = Enumerable.Range(1, arr.Length).ToArray();
        var expected = queries
            .Select(d => Enumerable.Range(0, arr.Length - d + 1).Min(start => arr.Skip(start).Take(d).Max()))
            .ToArray();

        Assert.Equal(expected, QueriesWithFixedLength.Solve(arr, queries));
    }

    [Fact]
    public void MergingCommunities_Sample() =>
        Assert.Equal([1, 2, 3, 3], MergingCommunities.Solve(3, ["Q 1", "M 1 2", "Q 2", "M 2 3", "Q 3", "Q 2"]));

    [Fact]
    public void MedianUpdates_Sample() =>
        Assert.Equal(
            ["Wrong!", "1", "1.5", "1", "1.5", "1", "Wrong!"],
            MedianUpdates.Solve(["r 1", "a 1", "a 2", "a 1", "r 1", "r 2", "r 1"]));

    [Fact]
    public void MedianUpdates_HandlesNegativeHalves() =>
        Assert.Equal(["-3", "-2.5", "-2", "-0.5", "Wrong!"], MedianUpdates.Solve(["a -3", "a -2", "a 1", "r -3", "r 7"]));

    [Theory]
    [InlineData(new[] { 1, 0, 0 }, 2)]
    [InlineData(new[] { 0, 1, 2 }, 1)]
    [InlineData(new[] { 5, 5, 5 }, 1)]
    public void KindergartenAdventures_Samples(int[] t, int expected) =>
        Assert.Equal(expected, KindergartenAdventures.Solve(t));

    [Fact]
    public void KindergartenAdventures_MatchesBruteForce()
    {
        var random = new Random(5);
        for (int trial = 0; trial < 200; trial++)
        {
            var t = Enumerable.Range(0, random.Next(1, 9)).Select(_ => random.Next(0, 10)).ToArray();
            int n = t.Length;

            int Finished(int start) => Enumerable.Range(0, n).Count(i => (i - start + n) % n >= t[i]);
            int expected = Enumerable.Range(0, n).OrderByDescending(Finished).ThenBy(s => s).First() + 1;

            Assert.Equal(expected, KindergartenAdventures.Solve(t));
        }
    }

    [Fact]
    public void KunduAndTree_Sample() =>
        Assert.Equal(4L, KunduAndTree.Solve(5, ["1 2 b", "2 3 r", "3 4 r", "4 5 b"]));

    [Fact]
    public void KunduAndTree_AllRedCountsEveryTriplet() =>
        Assert.Equal(10L, KunduAndTree.Solve(5, ["1 2 r", "2 3 r", "3 4 r", "4 5 r"]));

    [Fact]
    public void RansomNote_Samples()
    {
        Assert.Equal("Yes", RansomNote.Solve("give me one grand today night".Split(' '), "give one grand today".Split(' ')));
        Assert.Equal("No", RansomNote.Solve("two times three is not four".Split(' '), "two times two is four".Split(' ')));
        Assert.Equal("No", RansomNote.Solve("ive got a lovely bunch of coconuts".Split(' '), "ive got some coconuts".Split(' ')));
        Assert.Equal("No", RansomNote.Solve(["Attack"], ["attack"]));
    }

    [Fact]
    public void FrequencyQueries_Samples()
    {
        Assert.Equal([0, 1], FrequencyQueries.Solve([[1, 5], [1, 6], [3, 2], [1, 10], [1, 10], [1, 6], [2, 5], [3, 2]]));
        Assert.Equal([0, 1], FrequencyQueries.Solve([[3, 4], [2, 1003], [1, 16], [3, 1]]));
        Assert.Equal([0, 1, 1], FrequencyQueries.Solve([[1, 3], [2, 3], [3, 2], [1, 4], [1, 5], [1, 5], [1, 4], [3, 2], [2, 4], [3, 2]]));
    }

    [Theory]
    [InlineData(new[] { 2L, 6L, 1L, 12L }, new[] { 12L, 2L, 1L, 1L })]
    [InlineData(new[] { 1L, 2L, 3L, 5L, 1L, 13L, 3L }, new[] { 13L, 3L, 2L, 1L, 1L, 1L, 1L })]
    [InlineData(new[] { 3L, 5L, 4L, 7L, 6L, 2L }, new[] { 7L, 6L, 4L, 4L, 3L, 2L })]
    public void MinMaxRiddle_Samples(long[] arr, long[] expected) =>
        Assert.Equal(expected, MinMaxRiddle.Solve(arr));

    [Fact]
    public void MinMaxRiddle_MatchesBruteForce()
    {
        var random = new Random(41);
        for (int trial = 0; trial < 100; trial++)
        {
            var arr = Enumerable.Range(0, random.Next(1, 10)).Select(_ => (long)random.Next(0, 20)).ToArray();
            var expected = Enumerable.Range(1, arr.Length)
                .Select(w => Enumerable.Range(0, arr.Length - w + 1).Max(s => arr.Skip(s).Take(w).Min()))
                .ToArray();

            Assert.Equal(expected, MinMaxRiddle.Solve(arr));
        }
    }

    [Fact]
    public void MaxCircle_Sample() =>
        Assert.Equal([2, 2, 4, 4, 4, 7], MaxCircle.Solve([[1, 2], [3, 4], [1, 3], [5, 7], [5, 6], [7, 4]]));

    [Fact]
    public void MaxCircle_HandlesLargeIds() =>
        Assert.Equal([2, 2, 4], MaxCircle.Solve([[1_000_000_000, 1], [5, 6], [6, 1]]));

    [Fact]
    public void SuperMaximumCostQueries_Sample() =>
        Assert.Equal(
            [1L, 3L, 5L, 5L, 10L],
            SuperMaximumCostQueries.Solve(5, [[1, 2, 3], [1, 4, 2], [2, 5, 6], [3, 4, 1]], [[1, 1], [1, 2], [2, 3], [2, 5], [1, 6]]));

    [Fact]
    public void SuperMaximumCostQueries_HandlesEqualWeights() =>
        Assert.Equal([3L, 0L], SuperMaximumCostQueries.Solve(3, [[1, 2, 4], [2, 3, 4]], [[4, 4], [5, 9]]));

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, 6L)]
    [InlineData(new[] { 1, 2, 3, 4 }, new[] { 10, 20, 30, 40 }, 100L)]
    [InlineData(new[] { 1, 2, 3, 4, 1, 2, 3, 4 }, new[] { 10, 20, 30, 40, 15, 15, 15, 50 }, 110L)]
    [InlineData(new[] { 5, 5, 5 }, new[] { 1, 9, 2 }, 9L)]
    public void SubsequenceWeighting_Samples(int[] a, int[] w, long expected) =>
        Assert.Equal(expected, SubsequenceWeighting.Solve(a, w));

    [Fact]
    public void CubeSummation_Samples()
    {
        Assert.Equal(
            [4L, 4L, 27L],
            CubeSummation.Solve(4, ["UPDATE 2 2 2 4", "QUERY 1 1 1 3 3 3", "UPDATE 1 1 1 23", "QUERY 2 2 2 4 4 4", "QUERY 1 1 1 3 3 3"]));
        Assert.Equal(
            [0L, 1L, 1L],
            CubeSummation.Solve(2, ["UPDATE 2 2 2 1", "QUERY 1 1 1 1 1 1", "QUERY 1 1 1 2 2 2", "QUERY 2 2 2 2 2 2"]));
    }

    [Fact]
    public void CubeSummation_UpdateOverwritesCell() =>
        Assert.Equal([-5L], CubeSummation.Solve(3, ["UPDATE 1 2 3 10", "UPDATE 1 2 3 -5", "QUERY 1 1 1 3 3 3"]));

    [Fact]
    public void DirectConnections_Sample() =>
        Assert.Equal(280L, DirectConnections.Solve([1, 3, 6], [10, 20, 30]));

    [Fact]
    public void DirectConnections_MatchesBruteForce()
    {
        var random = new Random(43);
        for (int trial = 0; trial < 100; trial++)
        {
            int n = random.Next(1, 8);
            var x = Enumerable.Range(0, n).Select(_ => random.Next(1, 1000)).Distinct().ToArray();
            var p = x.Select(_ => random.Next(1, 100)).ToArray();

            long expected = 0;
            for (int i = 0; i < x.Length; i++)
                for (int j = i + 1; j < x.Length; j++)
                    expected += (long)Math.Abs(x[i] - x[j]) * Math.Max(p[i], p[j]);

            Assert.Equal(expected % 1_000_000_007, DirectConnections.Solve(x, p));
        }
    }

    [Fact]
    public void KthAncestor_MatchesParentWalk()
    {
        var random = new Random(157);
        for (int trial = 0; trial < 20; trial++)
        {
            // A random initial tree on 1..8, then random adds, leaf removals and queries.
            var parent = new Dictionary<int, int> { [1] = 0 };
            var edges = new List<int[]> { new[] { 1, 0 } };
            for (int node = 2; node <= 8; node++)
            {
                int p = random.Next(1, node);
                parent[node] = p;
                edges.Add([node, p]);
            }

            var queries = new List<string>();
            var expected = new List<long>();
            int nextId = 9;

            for (int step = 0; step < 60; step++)
            {
                int kind = random.Next(3);
                if (kind == 0)
                {
                    int p = parent.Keys.ElementAt(random.Next(parent.Count));
                    queries.Add($"0 {p} {nextId}");
                    parent[nextId++] = p;
                }
                else if (kind == 1)
                {
                    var leaves = parent.Keys.Where(x => !parent.Values.Contains(x)).ToArray();
                    if (leaves.Length > 1)
                    {
                        int leaf = leaves[random.Next(leaves.Length)];
                        queries.Add($"1 {leaf}");
                        parent.Remove(leaf);
                    }
                }
                else
                {
                    int x = random.Next(1, nextId + 2);
                    int k = random.Next(0, 6);
                    queries.Add($"2 {x} {k}");

                    long answer = 0;
                    if (parent.ContainsKey(x))
                    {
                        int at = x;
                        for (int i = 0; i < k && at != 0; i++)
                        {
                            at = parent[at];
                        }

                        answer = at;
                    }

                    expected.Add(answer);
                }
            }

            Assert.Equal(expected, KthAncestor.Solve(edges, queries));
        }
    }

    [Fact]
    public void ArrayAndSimpleQueries_Sample()
    {
        var (difference, final) = ArrayAndSimpleQueries.Solve([1, 2, 3, 4, 5, 6, 7, 8], [[1, 2, 4], [2, 3, 5], [1, 4, 7], [2, 1, 4]]);
        Assert.Equal(1L, difference);
        Assert.Equal([2, 3, 6, 5, 7, 8, 4, 1], final);
    }

    [Fact]
    public void ArrayAndSimpleQueries_MatchesListOperations()
    {
        var random = new Random(163);
        var list = Enumerable.Range(1, 30).ToList();
        var queries = new List<int[]>();

        for (int q = 0; q < 100; q++)
        {
            int i = random.Next(1, 31), j = random.Next(i, 31), type = random.Next(1, 3);
            queries.Add([type, i, j]);

            var segment = list.GetRange(i - 1, j - i + 1);
            list.RemoveRange(i - 1, j - i + 1);
            list.InsertRange(type == 1 ? 0 : list.Count, segment);
        }

        var (difference, final) = ArrayAndSimpleQueries.Solve(Enumerable.Range(1, 30).ToArray(), queries);
        Assert.Equal(list, final);
        Assert.Equal(Math.Abs(list[0] - list[^1]), difference);
    }

    [Fact]
    public void FindMaximumIndexProduct_Sample() =>
        Assert.Equal(8L, FindMaximumIndexProduct.Solve([5, 4, 3, 4, 5]));

    [Fact]
    public void FindMaximumIndexProduct_MatchesBruteForce()
    {
        var random = new Random(167);
        for (int trial = 0; trial < 100; trial++)
        {
            var a = Enumerable.Range(0, random.Next(1, 10)).Select(_ => random.Next(1, 6)).ToArray();
            long expected = Enumerable.Range(0, a.Length).Max(i =>
            {
                int left = Enumerable.Range(0, i).Reverse().FirstOrDefault(j => a[j] > a[i], -1) + 1;
                int right = Enumerable.Range(i + 1, a.Length - i - 1).FirstOrDefault(j => a[j] > a[i], -1) + 1;
                return (long)left * right;
            });

            Assert.Equal(expected, FindMaximumIndexProduct.Solve(a));
        }
    }

    [Fact]
    public void MrXAndHisShots_Sample() =>
        Assert.Equal(9L, MrXAndHisShots.Solve([[1, 2], [2, 3], [4, 5], [6, 7]], [[1, 5], [2, 3], [4, 7], [5, 7]]));

    [Fact]
    public void MrXAndHisShots_MatchesBruteForce()
    {
        var random = new Random(47);
        int[] Interval() { int a = random.Next(0, 30), b = random.Next(0, 30); return [Math.Min(a, b), Math.Max(a, b)]; }

        for (int trial = 0; trial < 100; trial++)
        {
            var shots = Enumerable.Range(0, random.Next(1, 8)).Select(_ => Interval()).ToArray();
            var players = Enumerable.Range(0, random.Next(1, 8)).Select(_ => Interval()).ToArray();
            long expected = shots.Sum(s => players.Count(p => s[0] <= p[1] && p[0] <= s[1]));

            Assert.Equal(expected, MrXAndHisShots.Solve(shots, players));
        }
    }
}
