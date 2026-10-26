namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Save the Prisoner! — <c>m</c> sweets are handed out around a circle of <c>n</c> prisoners
/// starting at seat <c>s</c>; return the seat that receives the last (bad) sweet.
/// https://www.hackerrank.com/challenges/save-the-prisoner
/// </summary>
public static class SaveThePrisoner
{
    public static int Solve(int n, int m, int s)
    {
        // long arithmetic: s + m can exceed int.MaxValue under the problem's constraints.
        return (int)(((long)s - 1 + m - 1) % n + 1);
    }
}
