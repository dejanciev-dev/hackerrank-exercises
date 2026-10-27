namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Permutation Game — Alice and Bob take turns removing one number; whoever leaves the
/// sequence increasing wins. n ≤ 15, so memoise over the bitmask of remaining positions:
/// a position is winning if some removal either finishes the game or hands the opponent a
/// losing position. O(2^n · n²).
/// https://www.hackerrank.com/challenges/permutation-game
/// </summary>
public static class PermutationGame
{
    public static string Solve(IReadOnlyList<int> arr)
    {
        var memo = new sbyte[1 << arr.Count];
        return Wins(arr, (1 << arr.Count) - 1, memo) ? "Alice" : "Bob";
    }

    private static bool Wins(IReadOnlyList<int> arr, int mask, sbyte[] memo)
    {
        if (memo[mask] != 0)
        {
            return memo[mask] > 0;
        }

        bool wins = false;
        for (int i = 0; i < arr.Count && !wins; i++)
        {
            if ((mask & (1 << i)) == 0)
            {
                continue;
            }

            int next = mask & ~(1 << i);
            wins = IsIncreasing(arr, next) || !Wins(arr, next, memo);
        }

        memo[mask] = wins ? (sbyte)1 : (sbyte)-1;
        return wins;
    }

    private static bool IsIncreasing(IReadOnlyList<int> arr, int mask)
    {
        int previous = int.MinValue;
        for (int i = 0; i < arr.Count; i++)
        {
            if ((mask & (1 << i)) != 0)
            {
                if (arr[i] <= previous)
                {
                    return false;
                }

                previous = arr[i];
            }
        }

        return true;
    }
}
