namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// Candies — each child gets at least one candy, and a child rated higher than a neighbor must
/// get more than that neighbor. Minimum total: satisfy left neighbors in a forward pass and
/// right neighbors in a backward pass. O(n).
/// https://www.hackerrank.com/challenges/candies
/// </summary>
public static class Candies
{
    public static long Solve(IReadOnlyList<int> arr)
    {
        int n = arr.Count;
        var candies = new long[n];
        Array.Fill(candies, 1);

        for (int i = 1; i < n; i++)
        {
            if (arr[i] > arr[i - 1])
            {
                candies[i] = candies[i - 1] + 1;
            }
        }

        for (int i = n - 2; i >= 0; i--)
        {
            if (arr[i] > arr[i + 1])
            {
                candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
            }
        }

        return candies.Sum();
    }
}
