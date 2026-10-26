namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Running Time of Algorithms — count the shifts insertion sort performs on the array.
/// https://www.hackerrank.com/challenges/runningtime
/// </summary>
public static class RunningTimeOfAlgorithms
{
    public static int Solve(IReadOnlyList<int> arr)
    {
        var values = arr.ToArray();
        int shifts = 0;

        for (int i = 1; i < values.Length; i++)
        {
            int value = values[i];
            int j = i - 1;

            while (j >= 0 && values[j] > value)
            {
                values[j + 1] = values[j];
                j--;
                shifts++;
            }

            values[j + 1] = value;
        }

        return shifts;
    }
}
