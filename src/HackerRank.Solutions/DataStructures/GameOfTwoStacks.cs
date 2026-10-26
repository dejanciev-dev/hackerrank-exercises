namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Game of Two Stacks — remove integers from the tops of stacks a and b (index 0 is the top)
/// while the running sum stays within <c>maxSum</c>; return the most removals possible.
/// Take greedily from a, then slide: add each element of b and give back elements of a as needed.
/// https://www.hackerrank.com/challenges/game-of-two-stacks
/// </summary>
public static class GameOfTwoStacks
{
    public static int Solve(long maxSum, IReadOnlyList<int> a, IReadOnlyList<int> b)
    {
        long sum = 0;
        int fromA = 0;

        while (fromA < a.Count && sum + a[fromA] <= maxSum)
        {
            sum += a[fromA++];
        }

        int best = fromA;

        for (int fromB = 1; fromB <= b.Count; fromB++)
        {
            sum += b[fromB - 1];

            while (sum > maxSum && fromA > 0)
            {
                sum -= a[--fromA];
            }

            if (sum > maxSum)
            {
                break;
            }

            best = Math.Max(best, fromA + fromB);
        }

        return best;
    }
}
