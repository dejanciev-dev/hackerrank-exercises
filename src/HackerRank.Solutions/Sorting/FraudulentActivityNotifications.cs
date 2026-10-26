namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Fraudulent Activity Notifications — send a notification whenever a day's spending is at
/// least twice the median of the previous <c>d</c> days. Spending is bounded (0..200), so a
/// counting-sort window gives each median in O(200) instead of re-sorting: O(n · 200) overall.
/// https://www.hackerrank.com/challenges/fraudulent-activity-notifications
/// </summary>
public static class FraudulentActivityNotifications
{
    private const int MaxExpenditure = 200;

    public static int Solve(IReadOnlyList<int> expenditure, int d)
    {
        var counts = new int[MaxExpenditure + 1];
        int notifications = 0;

        for (int i = 0; i < expenditure.Count; i++)
        {
            if (i >= d)
            {
                if (expenditure[i] >= TwiceMedian(counts, d))
                {
                    notifications++;
                }

                counts[expenditure[i - d]]--;
            }

            counts[expenditure[i]]++;
        }

        return notifications;
    }

    // Twice the median keeps the comparison in integers for even window sizes.
    private static int TwiceMedian(int[] counts, int d)
    {
        return d % 2 == 1
            ? 2 * KthSmallest(counts, d / 2 + 1)
            : KthSmallest(counts, d / 2) + KthSmallest(counts, d / 2 + 1);
    }

    private static int KthSmallest(int[] counts, int k)
    {
        int seen = 0;
        for (int value = 0; value < counts.Length; value++)
        {
            seen += counts[value];
            if (seen >= k)
            {
                return value;
            }
        }

        throw new InvalidOperationException("Window holds fewer than k elements.");
    }
}
