namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Arrays - DS — reverse an array in place with two pointers.
/// https://www.hackerrank.com/challenges/arrays-ds
/// </summary>
public static class ArraysDS
{
    public static int[] Solve(IReadOnlyList<int> a)
    {
        var result = a.ToArray();

        for (int left = 0, right = result.Length - 1; left < right; left++, right--)
        {
            (result[left], result[right]) = (result[right], result[left]);
        }

        return result;
    }
}
