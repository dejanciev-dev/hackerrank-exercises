namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Restaurant — fewest equal squares an l x b loaf can be cut into. The largest square side
/// that divides both is gcd(l, b), giving (l / g) · (b / g) squares.
/// https://www.hackerrank.com/challenges/restaurant
/// </summary>
public static class Restaurant
{
    public static int Solve(int l, int b)
    {
        int g = Gcd(l, b);
        return l / g * (b / g);
    }

    private static int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);
}
