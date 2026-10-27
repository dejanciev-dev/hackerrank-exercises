using HackerRank.Solutions.GameTheory;

namespace HackerRank.Solutions.Tests;

/// <summary>
/// Most game-theory solutions are closed-form patterns, so besides the samples each one is
/// checked against a brute-force search of the game itself.
/// </summary>
public class GameTheoryTests
{
    [Theory]
    [InlineData(1, "Second")]
    [InlineData(2, "First")]
    [InlineData(3, "First")]
    [InlineData(4, "First")]
    [InlineData(5, "First")]
    [InlineData(6, "First")]
    [InlineData(7, "Second")]
    [InlineData(10, "First")]
    public void GameOfStones_Samples(int n, string expected) =>
        Assert.Equal(expected, GameOfStones.Solve(n));

    [Fact]
    public void GameOfStones_MatchesBruteForce()
    {
        var wins = new bool[200];
        for (int n = 1; n < wins.Length; n++)
        {
            wins[n] = new[] { 2, 3, 5 }.Any(take => take <= n && !wins[n - take]);
            Assert.Equal(wins[n] ? "First" : "Second", GameOfStones.Solve(n));
        }
    }

    [Theory]
    [InlineData(2, 2, 2)]
    [InlineData(1, 4, 1)]
    [InlineData(3, 1, 2)]
    [InlineData(3, 6, 1)]
    public void TowerBreakers_Samples(int n, int m, int expected) =>
        Assert.Equal(expected, TowerBreakers.Solve(n, m));

    [Theory]
    [InlineData(5, 2, "Second")]
    [InlineData(5, 3, "First")]
    [InlineData(8, 8, "First")]
    public void ChessboardGame_Samples(int x, int y, string expected) =>
        Assert.Equal(expected, ChessboardGame.Solve(x, y));

    [Fact]
    public void ChessboardGame_MatchesBruteForce()
    {
        var memo = new Dictionary<(int, int), bool>();

        bool Wins(int x, int y)
        {
            if (memo.TryGetValue((x, y), out bool known))
            {
                return known;
            }

            (int, int)[] moves = [(x - 2, y + 1), (x - 2, y - 1), (x + 1, y - 2), (x - 1, y - 2)];
            bool wins = moves.Any(m => m.Item1 is >= 1 and <= 15 && m.Item2 is >= 1 and <= 15 && !Wins(m.Item1, m.Item2));
            return memo[(x, y)] = wins;
        }

        for (int x = 1; x <= 15; x++)
        {
            for (int y = 1; y <= 15; y++)
            {
                Assert.Equal(Wins(x, y) ? "First" : "Second", ChessboardGame.Solve(x, y));
            }
        }
    }

    [Theory]
    [InlineData(new[] { 1, 1 }, "Second")]
    [InlineData(new[] { 2, 1, 4 }, "First")]
    public void IntroductionToNim_Samples(int[] pile, string expected) =>
        Assert.Equal(expected, IntroductionToNim.Solve(pile));

    [Theory]
    [InlineData(new[] { 1, 1 }, "First")]
    [InlineData(new[] { 2, 1, 3 }, "Second")]
    [InlineData(new[] { 1 }, "Second")]
    public void MisereNim_Samples(int[] s, string expected) =>
        Assert.Equal(expected, MisereNim.Solve(s));

    [Fact]
    public void MisereNim_MatchesBruteForce()
    {
        var memo = new Dictionary<string, bool>();

        // In misère play, facing an empty board means the opponent took the last stone.
        bool Wins(int[] piles)
        {
            string key = string.Join(',', piles.Order());
            if (memo.TryGetValue(key, out bool known))
            {
                return known;
            }

            bool wins = piles.All(p => p == 0);
            for (int i = 0; i < piles.Length && !wins; i++)
            {
                for (int take = 1; take <= piles[i] && !wins; take++)
                {
                    var next = (int[])piles.Clone();
                    next[i] -= take;
                    wins = !Wins(next);
                }
            }

            return memo[key] = wins;
        }

        // HackerRank guarantees every pile starts with at least one stone.
        foreach (var piles in AllPiles(count: 3, max: 4).Where(p => p.All(stones => stones > 0)))
        {
            Assert.Equal(Wins(piles) ? "First" : "Second", MisereNim.Solve(piles));
        }
    }

    [Theory]
    [InlineData(new[] { 0, 2, 3, 0, 6 }, "First")]
    [InlineData(new[] { 0, 0, 0, 0 }, "Second")]
    [InlineData(new[] { 0, 1, 1 }, "First")]
    public void NimbleGame_Samples(int[] s, string expected) =>
        Assert.Equal(expected, NimbleGame.Solve(s));

    [Theory]
    [InlineData(5, new[] { 1, 2 }, "First")]
    [InlineData(5, new[] { 2, 2 }, "Second")]
    public void PokerNim_Samples(int k, int[] c, string expected) =>
        Assert.Equal(expected, PokerNim.Solve(k, c));

    [Theory]
    [InlineData(new[] { 1, 2 }, 1)]
    [InlineData(new[] { 1, 2, 3 }, 2)]
    [InlineData(new[] { 4, 6 }, 2)]
    public void TowerBreakersRevisited_Samples(int[] h, int expected) =>
        Assert.Equal(expected, TowerBreakersRevisited.Solve(h));

    [Fact]
    public void TowerBreakersRevisited_MatchesBruteForce()
    {
        var memo = new Dictionary<string, bool>();

        bool Wins(int[] towers)
        {
            string key = string.Join(',', towers.Order());
            if (memo.TryGetValue(key, out bool known))
            {
                return known;
            }

            bool wins = false;
            for (int i = 0; i < towers.Length && !wins; i++)
            {
                for (int divisor = 1; divisor < towers[i] && !wins; divisor++)
                {
                    if (towers[i] % divisor == 0)
                    {
                        var next = (int[])towers.Clone();
                        next[i] = divisor;
                        wins = !Wins(next);
                    }
                }
            }

            return memo[key] = wins;
        }

        foreach (var towers in AllPiles(count: 2, max: 24).Where(t => t.All(h => h > 0)))
        {
            Assert.Equal(Wins(towers) ? 1 : 2, TowerBreakersRevisited.Solve(towers));
        }
    }

    [Theory]
    [InlineData(1, "Bob")]
    [InlineData(2, "Alice")]
    [InlineData(5, "Alice")]
    [InlineData(10, "Bob")]
    public void AliceAndBobsSillyGame_Samples(int n, string expected) =>
        Assert.Equal(expected, AliceAndBobsSillyGame.Solve(n));

    [Theory]
    [InlineData(new[] { 1, 2 }, "W")]
    [InlineData(new[] { 2, 2 }, "L")]
    public void ZeroMoveNim_Samples(int[] p, string expected) =>
        Assert.Equal(expected, ZeroMoveNim.Solve(p));

    [Fact]
    public void ZeroMoveNim_MatchesBruteForce()
    {
        var memo = new Dictionary<string, bool>();

        // Each pile is (stones, zero move still available).
        bool Wins((int Stones, bool Zero)[] piles)
        {
            string key = string.Join(',', piles.Order());
            if (memo.TryGetValue(key, out bool known))
            {
                return known;
            }

            bool wins = false;
            for (int i = 0; i < piles.Length && !wins; i++)
            {
                for (int take = 1; take <= piles[i].Stones && !wins; take++)
                {
                    var next = ((int, bool)[])piles.Clone();
                    next[i] = (piles[i].Stones - take, piles[i].Zero);
                    wins = !Wins(next);
                }

                if (!wins && piles[i].Zero && piles[i].Stones > 0)
                {
                    var next = ((int, bool)[])piles.Clone();
                    next[i] = (piles[i].Stones, false);
                    wins = !Wins(next);
                }
            }

            return memo[key] = wins;
        }

        foreach (var piles in AllPiles(count: 2, max: 7).Concat(AllPiles(count: 3, max: 4)))
        {
            var start = piles.Select(stones => (stones, true)).ToArray();
            Assert.Equal(Wins(start) ? "W" : "L", ZeroMoveNim.Solve(piles));
        }
    }

    [Theory]
    [InlineData("IXXI", "LOSE")]
    [InlineData("XIIX", "WIN")]
    [InlineData("IIXII", "LOSE")]
    [InlineData("III", "WIN")]
    public void BowlingPins_Samples(string config, string expected) =>
        Assert.Equal(expected, BowlingPins.Solve(config));

    [Fact]
    public void BowlingPins_MatchesBruteForce()
    {
        var memo = new Dictionary<string, bool>();

        bool Wins(string pins)
        {
            if (memo.TryGetValue(pins, out bool known))
            {
                return known;
            }

            bool wins = false;
            for (int i = 0; i < pins.Length && !wins; i++)
            {
                if (pins[i] != 'I')
                {
                    continue;
                }

                wins = !Wins(pins[..i] + "X" + pins[(i + 1)..]);
                if (!wins && i + 1 < pins.Length && pins[i + 1] == 'I')
                {
                    wins = !Wins(pins[..i] + "XX" + pins[(i + 2)..]);
                }
            }

            return memo[pins] = wins;
        }

        for (int mask = 1; mask < 1 << 10; mask++)
        {
            string pins = new(Enumerable.Range(0, 10).Select(i => (mask & (1 << i)) != 0 ? 'I' : 'X').ToArray());
            Assert.Equal(Wins(pins) ? "WIN" : "LOSE", BowlingPins.Solve(pins));
        }
    }

    [Fact]
    public void ChessboardGameAgain_SingleCoinMatchesChessboardGame()
    {
        for (int x = 1; x <= 15; x++)
        {
            for (int y = 1; y <= 15; y++)
            {
                Assert.Equal(ChessboardGame.Solve(x, y), ChessboardGameAgain.Solve([[x, y]]));
            }
        }
    }

    [Fact]
    public void ChessboardGameAgain_IdenticalCoinsCancel() =>
        Assert.Equal("Second", ChessboardGameAgain.Solve([[5, 3], [5, 3]]));

    [Theory]
    [InlineData(new[] { 1, 3, 2 }, "Alice")]
    [InlineData(new[] { 5, 3, 2, 1, 4 }, "Bob")]
    [InlineData(new[] { 2, 1 }, "Alice")]
    public void PermutationGame_Samples(int[] arr, string expected) =>
        Assert.Equal(expected, PermutationGame.Solve(arr));

    [Fact]
    public void PowersGame_MatchesBruteForce()
    {
        for (int n = 1; n <= 16; n++)
        {
            var powers = Enumerable.Range(1, n).Select(i => (int)System.Numerics.BigInteger.ModPow(2, i, 17)).ToArray();
            var memo = new Dictionary<(int, int), bool>();

            // Whether the first player wins, given the unsigned powers and the sum so far mod 17.
            bool FirstWins(int unsigned, int sum)
            {
                if (unsigned == 0)
                {
                    return sum != 0;
                }

                if (memo.TryGetValue((unsigned, sum), out bool known))
                {
                    return known;
                }

                bool firstToMove = (n - System.Numerics.BitOperations.PopCount((uint)unsigned)) % 2 == 0;
                var outcomes = new List<bool>();

                for (int i = 0; i < n; i++)
                {
                    if ((unsigned & (1 << i)) != 0)
                    {
                        int rest = unsigned & ~(1 << i);
                        outcomes.Add(FirstWins(rest, (sum + powers[i]) % 17));
                        outcomes.Add(FirstWins(rest, (sum - powers[i] + 17) % 17));
                    }
                }

                return memo[(unsigned, sum)] = firstToMove ? outcomes.Any(o => o) : outcomes.All(o => o);
            }

            Assert.Equal(FirstWins((1 << n) - 1, 0) ? "First" : "Second", PowersGame.Solve(n));
        }
    }

    [Fact]
    public void KittyAndKatty_MatchesBruteForce()
    {
        var memo = new Dictionary<(int, int, int, bool), bool>();

        // Residue counts mod 3; returns whether Kitty wins with `kittyToMove` to play.
        bool KittyWins(int c0, int c1, int c2, bool kittyToMove)
        {
            if (c0 + c1 + c2 == 1)
            {
                // The last mover is the one who isn't to move now.
                return c1 == 1 || (c0 == 1 && !kittyToMove);
            }

            if (memo.TryGetValue((c0, c1, c2, kittyToMove), out bool known))
            {
                return known;
            }

            int[] counts = [c0, c1, c2];
            bool kittyCanWin = false;
            bool kattyCanWin = false;

            for (int a = 0; a < 3; a++)
            {
                for (int b = 0; b < 3; b++)
                {
                    var next = (int[])counts.Clone();
                    if (--next[a] < 0 || --next[b] < 0)
                    {
                        continue;
                    }

                    next[((a - b) % 3 + 3) % 3]++;
                    bool result = KittyWins(next[0], next[1], next[2], !kittyToMove);
                    kittyCanWin |= result;
                    kattyCanWin |= !result;
                }
            }

            return memo[(c0, c1, c2, kittyToMove)] = kittyToMove ? kittyCanWin : !kattyCanWin;
        }

        for (int n = 1; n <= 14; n++)
        {
            int[] counts = new int[3];
            for (int v = 1; v <= n; v++)
            {
                counts[v % 3]++;
            }

            Assert.Equal(KittyWins(counts[0], counts[1], counts[2], true) ? "Kitty" : "Katty", KittyAndKatty.Solve(n));
        }
    }

    [Fact]
    public void NewYearGame_MatchesBruteForce()
    {
        var memo = new Dictionary<(int, int, int, int, bool), bool>();

        // Remaining residue counts, Balsa minus Koca mod 3; returns whether Balsa wins.
        bool BalsaWins(int c0, int c1, int c2, int difference, bool balsaToMove)
        {
            if (c0 + c1 + c2 == 0)
            {
                return difference != 0;
            }

            if (memo.TryGetValue((c0, c1, c2, difference, balsaToMove), out bool known))
            {
                return known;
            }

            int[] counts = [c0, c1, c2];
            var outcomes = new List<bool>();

            for (int r = 0; r < 3; r++)
            {
                if (counts[r] == 0)
                {
                    continue;
                }

                var next = (int[])counts.Clone();
                next[r]--;
                int nextDifference = ((difference + (balsaToMove ? r : -r)) % 3 + 3) % 3;
                outcomes.Add(BalsaWins(next[0], next[1], next[2], nextDifference, !balsaToMove));
            }

            return memo[(c0, c1, c2, difference, balsaToMove)] = balsaToMove ? outcomes.Any(o => o) : outcomes.All(o => o);
        }

        foreach (var counts in AllPiles(count: 3, max: 5).Where(c => c.Sum() > 0))
        {
            var numbers = Enumerable.Repeat(3, counts[0]).Concat(Enumerable.Repeat(1, counts[1])).Concat(Enumerable.Repeat(2, counts[2])).ToArray();
            Assert.Equal(BalsaWins(counts[0], counts[1], counts[2], 0, true) ? "Balsa" : "Koca", NewYearGame.Solve(numbers));
        }
    }

    [Fact]
    public void StoneDivision_Sample() =>
        Assert.Equal("Second", StoneDivision.Solve(15, [5, 2, 3]));

    [Fact]
    public void StoneDivision_MatchesBruteForce()
    {
        long[][] sets = [[2], [3], [2, 3], [2, 4], [5, 2, 3], [3, 6], [2, 3, 4, 5, 6]];
        foreach (var s in sets)
        {
            var memo = new Dictionary<string, bool>();

            // Full game: the position is the multiset of piles.
            bool Wins(List<long> piles)
            {
                string key = string.Join(',', piles.Order());
                if (memo.TryGetValue(key, out bool known))
                {
                    return known;
                }

                bool wins = false;
                for (int i = 0; i < piles.Count && !wins; i++)
                {
                    foreach (var parts in s.Where(p => p > 1 && piles[i] % p == 0))
                    {
                        var next = piles.Where((_, j) => j != i).Concat(Enumerable.Repeat(piles[i] / parts, (int)parts)).ToList();
                        if (!Wins(next))
                        {
                            wins = true;
                            break;
                        }
                    }
                }

                return memo[key] = wins;
            }

            for (long n = 1; n <= 24; n++)
            {
                Assert.Equal(Wins([n]) ? "First" : "Second", StoneDivision.Solve(n, s));
            }
        }
    }

    [Fact]
    public void Deforestation_MatchesBruteForce()
    {
        var random = new Random(83);
        for (int trial = 0; trial < 80; trial++)
        {
            int n = random.Next(1, 9);
            var edges = Enumerable.Range(2, n - 1).Select(v => new[] { random.Next(1, v), v }).ToArray();
            var memo = new Dictionary<int, bool>();

            // alive: mask of edges still attached to the root (edge e joins parent → node e + 2).
            bool Wins(int alive)
            {
                if (memo.TryGetValue(alive, out bool known))
                {
                    return known;
                }

                bool wins = false;
                for (int e = 0; e < edges.Length && !wins; e++)
                {
                    if ((alive & (1 << e)) == 0)
                    {
                        continue;
                    }

                    // Cut e, then drop every edge no longer connected to node 1.
                    int next = alive & ~(1 << e);
                    var reached = new HashSet<int> { 1 };
                    bool grew = true;
                    while (grew)
                    {
                        grew = false;
                        for (int f = 0; f < edges.Length; f++)
                        {
                            if ((next & (1 << f)) != 0 && reached.Contains(edges[f][0]) && reached.Add(edges[f][1]))
                            {
                                grew = true;
                            }
                        }
                    }

                    for (int f = 0; f < edges.Length; f++)
                    {
                        if (!reached.Contains(edges[f][1]))
                        {
                            next &= ~(1 << f);
                        }
                    }

                    wins = !Wins(next);
                }

                return memo[alive] = wins;
            }

            Assert.Equal(Wins((1 << edges.Length) - 1) ? "Alice" : "Bob", Deforestation.Solve(n, edges));
        }
    }

    [Theory]
    [InlineData(new[] { 1, 3, 4 }, new[] { 5, 3, 1 }, "First")]
    [InlineData(new[] { 1, 1 }, new[] { 1, 1 }, "Tie")]
    [InlineData(new[] { 2, 2 }, new[] { 3, 3 }, "Second")]
    public void FunGame_Samples(int[] a, int[] b, string expected) =>
        Assert.Equal(expected, FunGame.Solve(a, b));

    [Fact]
    public void FunGame_MatchesMinimax()
    {
        var random = new Random(89);
        for (int trial = 0; trial < 100; trial++)
        {
            int n = random.Next(1, 8);
            var a = Enumerable.Range(0, n).Select(_ => random.Next(1, 10)).ToArray();
            var b = Enumerable.Range(0, n).Select(_ => random.Next(1, 10)).ToArray();
            var memo = new Dictionary<int, long>();

            // Best (first's score - second's score) from here, with optimal play by both.
            long Difference(int used)
            {
                if (used == (1 << n) - 1)
                {
                    return 0;
                }

                if (memo.TryGetValue(used, out long known))
                {
                    return known;
                }

                bool firstToMove = System.Numerics.BitOperations.PopCount((uint)used) % 2 == 0;
                long best = firstToMove ? long.MinValue : long.MaxValue;
                for (int i = 0; i < n; i++)
                {
                    if ((used & (1 << i)) != 0)
                    {
                        continue;
                    }

                    long value = Difference(used | (1 << i)) + (firstToMove ? a[i] : -b[i]);
                    best = firstToMove ? Math.Max(best, value) : Math.Min(best, value);
                }

                return memo[used] = best;
            }

            long difference = Difference(0);
            Assert.Equal(difference > 0 ? "First" : difference < 0 ? "Second" : "Tie", FunGame.Solve(a, b));
        }
    }

    [Theory]
    [InlineData(new[] { 1, 2 }, 1)]
    [InlineData(new[] { 1, 2, 3 }, 2)]
    [InlineData(new[] { 1 }, 2)]
    public void TowerBreakersAgain_Samples(int[] h, int expected) =>
        Assert.Equal(expected, TowerBreakersAgain.Solve(h));

    [Fact]
    public void TowerBreakersAgain_MatchesStoneDivisionWithEveryDivisor()
    {
        for (int height = 1; height <= 40; height++)
        {
            var divisors = Enumerable.Range(2, Math.Max(0, height - 1)).Select(d => (long)d).ToArray();
            string stoneDivision = StoneDivision.Solve(height, divisors);
            Assert.Equal(stoneDivision == "First" ? 1 : 2, TowerBreakersAgain.Solve([height]));
        }
    }

    [Theory]
    [InlineData(new[] { 2, 3 }, 1)]
    [InlineData(new[] { 1, 1 }, 0)]
    [InlineData(new[] { 3, 4, 5 }, 1)]
    public void ChocolateInBox_Samples(int[] a, int expected) =>
        Assert.Equal(expected, ChocolateInBox.Solve(a));

    [Fact]
    public void ChocolateInBox_CountsMovesThatZeroTheNimSum()
    {
        foreach (var piles in AllPiles(count: 3, max: 6))
        {
            int expected = Enumerable.Range(0, piles.Length).Count(i =>
                Enumerable.Range(0, piles[i]).Any(left => piles.Select((p, j) => j == i ? left : p).Aggregate(0, (x, v) => x ^ v) == 0));

            Assert.Equal(expected, ChocolateInBox.Solve(piles));
        }
    }

    private static IEnumerable<int[]> AllPiles(int count, int max)
    {
        if (count == 0)
        {
            yield return [];
            yield break;
        }

        foreach (var rest in AllPiles(count - 1, max))
        {
            for (int pile = 0; pile <= max; pile++)
            {
                yield return [pile, .. rest];
            }
        }
    }
}
