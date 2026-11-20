namespace HackerRank.Solutions.BitManipulation;

/// <summary>
/// Maximum Xor — given an array of non-negative integers and a list of queries, report for each
/// query value x the largest x XOR a[i] over all array elements.
/// The array goes into a binary trie (most significant bit first); a query then walks down the
/// trie, always preferring the child whose bit differs from the query's bit, which makes each
/// bit of the result 1 whenever the array allows it. O((n + q) · 31).
/// https://www.hackerrank.com/challenges/maximum-xor
/// </summary>
public static class MaximumXor
{
    private const int Bits = 31;

    public static int[] Solve(IReadOnlyList<int> arr, IReadOnlyList<int> queries)
    {
        // Trie nodes live in flat arrays: child[2 * node + bit] is the next node, 0 meaning none.
        var child = new int[2 * (arr.Count * Bits + 1)];
        int nodes = 1;

        foreach (var value in arr)
        {
            int node = 0;
            for (int bit = Bits - 1; bit >= 0; bit--)
            {
                int slot = 2 * node + (value >> bit & 1);
                if (child[slot] == 0)
                {
                    child[slot] = nodes++;
                }

                node = child[slot];
            }
        }

        var result = new int[queries.Count];
        for (int q = 0; q < queries.Count; q++)
        {
            int x = queries[q];
            int node = 0;
            int best = 0;

            for (int bit = Bits - 1; bit >= 0; bit--)
            {
                int want = (x >> bit & 1) ^ 1;
                if (child[2 * node + want] != 0)
                {
                    best |= 1 << bit;
                    node = child[2 * node + want];
                }
                else
                {
                    node = child[2 * node + (want ^ 1)];
                }
            }

            result[q] = best;
        }

        return result;
    }
}
