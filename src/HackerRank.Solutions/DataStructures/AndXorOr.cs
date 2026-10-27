namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// AND xor OR — the maximum of ((M1 AND M2) XOR (M1 OR M2)) AND (M1 XOR M2) over all
/// subarrays, where M1 and M2 are the subarray's two smallest values. The expression
/// simplifies to M1 XOR M2, and every pair that can be the two smallest of some subarray is a
/// pair of neighbours in a monotonic increasing stack. O(n).
/// https://www.hackerrank.com/challenges/and-xor-or
/// </summary>
public static class AndXorOr
{
    public static int Solve(IReadOnlyList<int> a)
    {
        var stack = new Stack<int>();
        int best = 0;

        foreach (var value in a)
        {
            while (stack.Count > 0)
            {
                best = Math.Max(best, stack.Peek() ^ value);
                if (stack.Peek() <= value)
                {
                    break;
                }

                stack.Pop();
            }

            stack.Push(value);
        }

        return best;
    }
}
