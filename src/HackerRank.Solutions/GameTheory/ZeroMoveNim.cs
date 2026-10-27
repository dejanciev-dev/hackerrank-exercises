namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Zero-Move Nim — Nim where each pile also allows one "zero move" (removing nothing).
/// Computing Grundy numbers by hand shows a pile of n has Grundy value n + 1 when n is odd and
/// n - 1 when n is even (and positive). XOR them as in ordinary Nim: "W" if the first player
/// wins, otherwise "L".
/// https://www.hackerrank.com/challenges/zero-move-nim
/// </summary>
public static class ZeroMoveNim
{
    public static string Solve(IReadOnlyList<int> p)
    {
        int nimSum = 0;
        foreach (var stones in p)
        {
            nimSum ^= Grundy(stones);
        }

        return nimSum != 0 ? "W" : "L";
    }

    private static int Grundy(int stones) => stones == 0 ? 0 : stones % 2 == 1 ? stones + 1 : stones - 1;
}
