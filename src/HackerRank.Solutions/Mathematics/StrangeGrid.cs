namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Strange Grid Again — the value at row r, column c of a five-column grid that counts up in
/// pairs of rows: row 1 holds 0 2 4 6 8, row 2 holds 1 3 5 7 9, row 3 starts at 10, and so on.
/// Closed form, O(1).
/// https://www.hackerrank.com/challenges/strange-grid
/// </summary>
public static class StrangeGrid
{
    public static long Solve(long r, long c) => (r - 1) / 2 * 10 + (r - 1) % 2 + 2 * (c - 1);
}
