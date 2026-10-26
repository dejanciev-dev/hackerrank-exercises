namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Left Rotation — rotate an array left by <c>d</c> positions. Each element lands at
/// index (i - d) mod n, so a single pass is enough.
/// https://www.hackerrank.com/challenges/array-left-rotation
/// </summary>
public static class LeftRotation
{
    public static int[] Solve(int d, IReadOnlyList<int> arr)
    {
        int n = arr.Count;
        var result = new int[n];

        for (int i = 0; i < n; i++)
        {
            result[i] = arr[(i + d) % n];
        }

        return result;
    }
}
