namespace HackerRank.Solutions.Sorting;

/// <summary>
/// Correctness and the Loop Invariant — insertion sort, written so that it is correct: at the
/// start of each outer iteration i, the prefix a[0..i-1] is sorted (the loop invariant). The
/// element a[i] is lifted out, larger elements of the prefix are shifted one place to the right,
/// and a[i] is dropped into the gap, which re-establishes the invariant for i + 1. The original
/// challenge is a buggy insertion sort to repair; the repaired sort is what is implemented here.
/// O(n²) comparisons in the worst case.
/// https://www.hackerrank.com/challenges/correctness-invariant
/// </summary>
public static class CorrectnessAndTheLoopInvariant
{
    public static int[] Solve(IReadOnlyList<int> arr)
    {
        var a = arr.ToArray();

        for (int i = 1; i < a.Length; i++)
        {
            int value = a[i];
            int j = i - 1;
            while (j >= 0 && a[j] > value)
            {
                a[j + 1] = a[j];
                j--;
            }

            a[j + 1] = value;
        }

        return a;
    }
}
