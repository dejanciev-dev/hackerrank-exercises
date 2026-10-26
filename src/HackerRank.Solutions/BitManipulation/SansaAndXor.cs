namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// Sansa and XOR — XOR together the XORs of every contiguous subarray. Element i appears in
/// (i + 1)(n - i) subarrays; that count is odd only when n is odd and i is even, so for an
/// even n everything cancels to 0.
/// https://www.hackerrank.com/challenges/sansa-and-xor
/// </summary>
public static class SansaAndXor
{
    public static int Solve(IReadOnlyList<int> arr)
    {
        if (arr.Count % 2 == 0)
        {
            return 0;
        }

        int result = 0;
        for (int i = 0; i < arr.Count; i += 2)
        {
            result ^= arr[i];
        }

        return result;
    }
}
