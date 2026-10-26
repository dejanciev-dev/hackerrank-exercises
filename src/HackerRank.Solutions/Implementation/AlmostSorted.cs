namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Almost Sorted — can the array be sorted with one swap or one segment reversal? Returns the
/// lines HackerRank expects: "yes" plus "swap l r" / "reverse l r" (1-based), or "no".
/// Swapping is preferred when both work.
/// https://www.hackerrank.com/challenges/almost-sorted
/// </summary>
public static class AlmostSorted
{
    public static string[] Solve(IReadOnlyList<int> arr)
    {
        var sorted = arr.Order().ToArray();

        int left = 0;
        while (left < arr.Count && arr[left] == sorted[left]) left++;

        if (left == arr.Count)
        {
            return ["yes"];
        }

        int right = arr.Count - 1;
        while (arr[right] == sorted[right]) right--;

        var candidate = arr.ToArray();

        (candidate[left], candidate[right]) = (candidate[right], candidate[left]);
        if (candidate.SequenceEqual(sorted))
        {
            return ["yes", $"swap {left + 1} {right + 1}"];
        }

        candidate = arr.ToArray();
        Array.Reverse(candidate, left, right - left + 1);
        if (candidate.SequenceEqual(sorted))
        {
            return ["yes", $"reverse {left + 1} {right + 1}"];
        }

        return ["no"];
    }
}
