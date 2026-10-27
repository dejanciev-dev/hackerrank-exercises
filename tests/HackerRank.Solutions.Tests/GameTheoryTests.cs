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
