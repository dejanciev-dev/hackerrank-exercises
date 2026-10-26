namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Cats and a Mouse — which cat (at x or y) reaches the mouse at z first?
/// https://www.hackerrank.com/challenges/cats-and-a-mouse
/// </summary>
public static class CatsAndAMouse
{
    public static string Solve(int x, int y, int z)
    {
        int catA = Math.Abs(x - z);
        int catB = Math.Abs(y - z);

        if (catA < catB) return "Cat A";
        if (catB < catA) return "Cat B";
        return "Mouse C";
    }
}
