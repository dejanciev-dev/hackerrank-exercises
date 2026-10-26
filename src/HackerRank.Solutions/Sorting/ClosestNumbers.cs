namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Closest Numbers — every pair of elements with the smallest absolute difference, flattened in
/// ascending order. After sorting, the closest pairs are always adjacent.
/// https://www.hackerrank.com/challenges/closest-numbers
/// </summary>
public static class ClosestNumbers
{
    public static int[] Solve(IReadOnlyList<int> arr)
    {
        var sorted = arr.Order().ToArray();
        long smallest = long.MaxValue;
        var pairs = new List<int>();

        for (int i = 1; i < sorted.Length; i++)
        {
            long difference = (long)sorted[i] - sorted[i - 1];

            if (difference < smallest)
            {
                smallest = difference;
                pairs.Clear();
            }

            if (difference == smallest)
            {
                pairs.Add(sorted[i - 1]);
                pairs.Add(sorted[i]);
            }
        }

        return pairs.ToArray();
    }
}
