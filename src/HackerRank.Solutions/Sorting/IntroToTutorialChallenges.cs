namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Intro to Tutorial Challenges — index of value <c>v</c> in a sorted array, found by binary search.
/// https://www.hackerrank.com/challenges/tutorial-intro
/// </summary>
public static class IntroToTutorialChallenges
{
    public static int Solve(int v, IReadOnlyList<int> arr)
    {
        int low = 0;
        int high = arr.Count - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            if (arr[mid] == v) return mid;
            if (arr[mid] < v) low = mid + 1;
            else high = mid - 1;
        }

        return -1;
    }
}
