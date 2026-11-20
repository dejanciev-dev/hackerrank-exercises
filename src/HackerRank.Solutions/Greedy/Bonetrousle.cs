namespace HackerRank.Solutions.Greedy;

/// <summary>
/// Bonetrousle — buy exactly n sticks using exactly k boxes of different types, where the box
/// of type i holds i sticks (1 ≤ i ≤ b). Report the sizes of the chosen boxes in increasing
/// order, or [-1] when it is impossible; any valid answer is accepted.
/// k different boxes hold between 1 + … + k and (b − k + 1) + … + b sticks, and every total in
/// between can be reached: start from the smallest boxes 1..k and push the largest boxes up, each
/// by at most b − k, which keeps all sizes distinct. O(k).
/// https://www.hackerrank.com/challenges/bonetrousle
/// </summary>
public static class Bonetrousle
{
    public static long[] Solve(long n, long k, long b)
    {
        long smallest = k * (k + 1) / 2;
        long largest = k * (2 * b - k + 1) / 2;
        if (k > b || n < smallest || n > largest)
        {
            return [-1];
        }

        var boxes = new long[k];
        for (int i = 0; i < k; i++)
        {
            boxes[i] = i + 1;
        }

        long extra = n - smallest;
        long room = b - k;

        // Raise the biggest boxes first; a raise of at most b - k keeps them below b and distinct.
        for (long i = k - 1; i >= 0 && extra > 0; i--)
        {
            long raise = Math.Min(extra, room);
            boxes[i] += raise;
            extra -= raise;
        }

        return boxes;
    }
}
