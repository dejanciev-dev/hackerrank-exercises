namespace HackerRank.Solutions.Recursion;

/// <summary>
/// Nikita and the Game — split the array into two non-empty parts with equal sums, keep
/// either part and repeat; one point per split. Find where the prefix sum reaches half the
/// total (binary search, since the values are non-negative), then recurse into both halves
/// and keep the better one. An all-zero part can be split n - 1 times.
/// https://www.hackerrank.com/challenges/array-splitting
/// </summary>
public static class NikitaAndTheGame
{
    public static int Solve(IReadOnlyList<int> arr)
    {
        var prefix = new long[arr.Count + 1];
        for (int i = 0; i < arr.Count; i++)
        {
            prefix[i + 1] = prefix[i] + arr[i];
        }

        return Score(prefix, 0, arr.Count);
    }

    /// <summary>Best score for the part covering indices [start, end).</summary>
    private static int Score(long[] prefix, int start, int end)
    {
        if (end - start < 2)
        {
            return 0;
        }

        long total = prefix[end] - prefix[start];
        if (total == 0)
        {
            return end - start - 1;
        }

        if (total % 2 != 0)
        {
            return 0;
        }

        long target = prefix[start] + total / 2;
        int split = Array.BinarySearch(prefix, start + 1, end - start - 1, target);
        if (split < 0)
        {
            return 0;
        }

        return 1 + Math.Max(Score(prefix, start, split), Score(prefix, split, end));
    }
}
