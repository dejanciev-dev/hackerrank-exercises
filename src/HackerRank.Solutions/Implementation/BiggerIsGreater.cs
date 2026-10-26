namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Bigger is Greater — the smallest rearrangement of <c>w</c> that is lexicographically greater,
/// or "no answer". This is the classic next-permutation algorithm in O(n).
/// https://www.hackerrank.com/challenges/bigger-is-greater
/// </summary>
public static class BiggerIsGreater
{
    public static string Solve(string w)
    {
        var chars = w.ToCharArray();

        // 1. Find the rightmost position whose character is smaller than its successor.
        int pivot = chars.Length - 2;
        while (pivot >= 0 && chars[pivot] >= chars[pivot + 1])
        {
            pivot--;
        }

        if (pivot < 0)
        {
            return "no answer";
        }

        // 2. Swap it with the rightmost character that is larger than it.
        int successor = chars.Length - 1;
        while (chars[successor] <= chars[pivot])
        {
            successor--;
        }

        (chars[pivot], chars[successor]) = (chars[successor], chars[pivot]);

        // 3. The suffix is in descending order; reverse it to make it as small as possible.
        Array.Reverse(chars, pivot + 1, chars.Length - pivot - 1);

        return new string(chars);
    }
}
