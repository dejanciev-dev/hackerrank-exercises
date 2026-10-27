namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Reverse Game — balls 0..n-1 are reversed from position 0, then from 1, and so on; where
/// does ball <c>k</c> end up? The final order alternates from both ends:
/// n-1, 0, n-2, 1, n-3, 2, ... so small balls land at odd indices and large ones at even. O(1).
/// https://www.hackerrank.com/challenges/reverse-game
/// </summary>
public static class ReverseGame
{
    public static int Solve(int n, int k) => k < n / 2 ? 2 * k + 1 : 2 * (n - 1 - k);
}
