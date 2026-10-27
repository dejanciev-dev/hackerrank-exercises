namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Baby Step, Giant Step — fewest jumps of length a or b (in any direction on the plane) to
/// travel distance d. 0 for d = 0, 1 if d is exactly a or b. Below b, two b-jumps at an
/// angle always meet any distance. Beyond that, ⌈d / b⌉ jumps of b (the last ones angled)
/// suffice and are needed.
/// https://www.hackerrank.com/challenges/baby-step-giant-step
/// </summary>
public static class BabyStepGiantStep
{
    public static long Solve(long a, long b, long d)
    {
        long small = Math.Min(a, b);
        long large = Math.Max(a, b);

        if (d == 0) return 0;
        if (d == small || d == large) return 1;
        if (d < large) return 2;
        return (d + large - 1) / large;
    }
}
