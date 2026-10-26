namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Circular Array Rotation — after <c>k</c> right rotations, return the element at each queried
/// index. Each answer is read straight from the original array in O(1); nothing is rotated.
/// https://www.hackerrank.com/challenges/circular-array-rotation
/// </summary>
public static class CircularArrayRotation
{
    public static int[] Solve(IReadOnlyList<int> a, int k, IReadOnlyList<int> queries)
    {
        int n = a.Count;
        int shift = k % n;

        return queries.Select(q => a[(q - shift + n) % n]).ToArray();
    }
}
