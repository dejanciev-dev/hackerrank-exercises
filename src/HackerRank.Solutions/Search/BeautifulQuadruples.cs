namespace HackerRank.Solutions.Search;

/// <summary>
/// Beautiful Quadruples — count the distinct multisets {W, X, Y, Z} with 1 ≤ W ≤ A, X ≤ B,
/// Y ≤ C, Z ≤ D (in some assignment) whose XOR is non-zero.
/// Sort the bounds and count sorted W ≤ X ≤ Y ≤ Z. Sweep Y upwards while a table holds how
/// many pairs W ≤ X ≤ Y produce each XOR value. Every Z ≥ Y then adds those pairs, minus the
/// ones with W ⊕ X = Y ⊕ Z. O(C · D + A · B).
/// https://www.hackerrank.com/challenges/xor-quadruples
/// </summary>
public static class BeautifulQuadruples
{
    public static long Solve(int a, int b, int c, int d)
    {
        int[] bounds = [a, b, c, d];
        Array.Sort(bounds);
        (a, b, c, d) = (bounds[0], bounds[1], bounds[2], bounds[3]);

        var pairsWithXor = new long[1 << 12];
        long pairs = 0, beautiful = 0;

        for (int y = 1; y <= c; y++)
        {
            if (y <= b)
            {
                for (int w = 1; w <= Math.Min(a, y); w++)
                {
                    pairsWithXor[w ^ y]++;
                    pairs++;
                }
            }

            for (int z = y; z <= d; z++)
            {
                beautiful += pairs - pairsWithXor[y ^ z];
            }
        }

        return beautiful;
    }
}
