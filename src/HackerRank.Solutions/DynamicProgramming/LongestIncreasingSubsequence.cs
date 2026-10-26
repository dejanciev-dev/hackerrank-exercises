namespace HackerRank.Solutions.DynamicProgramming;

/// <summary>
/// The Longest Increasing Subsequence — length of the longest strictly increasing subsequence.
/// tails[i] holds the smallest possible tail of an increasing subsequence of length i + 1;
/// binary search places each element. O(n log n).
/// https://www.hackerrank.com/challenges/longest-increasing-subsequent
/// </summary>
public static class LongestIncreasingSubsequence
{
    public static int Solve(IReadOnlyList<int> arr)
    {
        var tails = new List<int>();

        foreach (var value in arr)
        {
            int index = tails.BinarySearch(value);
            if (index >= 0)
            {
                continue; // equal values can't extend a strictly increasing subsequence
            }

            index = ~index;
            if (index == tails.Count)
            {
                tails.Add(value);
            }
            else
            {
                tails[index] = value;
            }
        }

        return tails.Count;
    }
}
