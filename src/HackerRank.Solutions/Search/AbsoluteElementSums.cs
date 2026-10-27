namespace HackerRank.Solutions.Search;

/// <summary>
/// Playing With Numbers — each query adds x to every element and asks for the sum of
/// absolute values. Only the running total shift matters. With the original array sorted and
/// prefix-summed, a binary search finds which elements are negative after shifting, and the
/// sum follows in O(log n) per query.
/// https://www.hackerrank.com/challenges/playing-with-numbers
/// </summary>
public static class AbsoluteElementSums
{
    public static long[] Solve(IReadOnlyList<int> arr, IReadOnlyList<int> queries)
    {
        var sorted = arr.Select(v => (long)v).Order().ToArray();
        var prefix = new long[sorted.Length + 1];
        for (int i = 0; i < sorted.Length; i++)
        {
            prefix[i + 1] = prefix[i] + sorted[i];
        }

        long n = sorted.Length;
        long shift = 0;
        var answers = new long[queries.Count];

        for (int q = 0; q < queries.Count; q++)
        {
            shift += queries[q];

            // Elements below -shift become negative.
            int negatives = LowerBound(sorted, -shift);
            long negativeSum = prefix[negatives] + shift * negatives;
            long positiveSum = prefix[n] - prefix[negatives] + shift * (n - negatives);
            answers[q] = positiveSum - negativeSum;
        }

        return answers;
    }

    private static int LowerBound(long[] sorted, long value)
    {
        int low = 0, high = sorted.Length;
        while (low < high)
        {
            int mid = (low + high) / 2;
            if (sorted[mid] < value) low = mid + 1;
            else high = mid;
        }

        return low;
    }
}
