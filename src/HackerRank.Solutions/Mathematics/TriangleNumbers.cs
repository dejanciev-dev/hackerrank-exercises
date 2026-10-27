namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Triangle Numbers — in the triangle where each entry is the sum of the three entries above
/// it, the position of the first even number in row n (or -1). Looking at the rows mod 2
/// shows a pattern with period 4: rows 1 and 2 have none, odd rows start with an even number
/// at position 2, rows divisible by 4 at position 3, and the remaining even rows at 4.
/// https://www.hackerrank.com/challenges/triangle-numbers
/// </summary>
public static class TriangleNumbers
{
    public static int Solve(int n) => n switch
    {
        <= 2 => -1,
        _ when n % 2 == 1 => 2,
        _ when n % 4 == 0 => 3,
        _ => 4,
    };
}
