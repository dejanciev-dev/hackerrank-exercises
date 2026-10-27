namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Wet Shark and 42 — walking squares 1, 2, 3, ..., Wet Shark loses 1 strength on every even
/// square except multiples of 42; on which square does strength S run out (modulo 1e9+7)?
/// Of every 21 consecutive even squares, 20 cost strength. So the S-th costly one is the
/// (S + ⌊(S - 1) / 20⌋)-th even square.
/// https://www.hackerrank.com/challenges/wet-shark-and-42
/// </summary>
public static class WetSharkAnd42
{
    public static long Solve(long s) => 2 * ((s + (s - 1) / 20) % ModularMath.Prime) % ModularMath.Prime;
}
