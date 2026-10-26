namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Climbing the Leaderboard — dense-ranked leaderboard; return the player's rank after each game.
/// Scores only increase, so a single pointer moves up the deduplicated board: O(n + m).
/// https://www.hackerrank.com/challenges/climbing-the-leaderboard
/// </summary>
public static class ClimbingTheLeaderboard
{
    public static int[] Solve(IReadOnlyList<int> ranked, IReadOnlyList<int> player)
    {
        var board = ranked.Distinct().ToArray(); // already sorted descending
        var result = new int[player.Count];
        int position = board.Length - 1;

        for (int i = 0; i < player.Count; i++)
        {
            while (position >= 0 && player[i] >= board[position])
            {
                position--;
            }

            // position is the index of the last score strictly greater than the player's.
            result[i] = position + 2;
        }

        return result;
    }
}
