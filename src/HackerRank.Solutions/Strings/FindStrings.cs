namespace HackerRank.Solutions.Strings;

/// <summary>
/// Find Strings — take every distinct substring of all the given words, sort them, and answer
/// "what is the k-th?" queries (or "INVALID"). Join the words with distinct separators below
/// 'a' and build one suffix array. Each suffix adds the substrings that are longer than its
/// LCP with the previous suffix and stop before the next separator. Prefix sums of those
/// counts plus binary search answer each query. O(N log² N + q log N).
/// https://www.hackerrank.com/challenges/find-strings
/// </summary>
public static class FindStrings
{
    public static string[] Solve(IReadOnlyList<string> w, IReadOnlyList<long> queries)
    {
        var text = new System.Text.StringBuilder();
        for (int i = 0; i < w.Count; i++)
        {
            text.Append(w[i]).Append((char)(i + 1));
        }

        string s = text.ToString();
        var order = SuffixArray.Build(s);
        var lcp = SuffixArray.Lcp(s, order);

        // limit[p]: characters from p up to (not including) the next separator.
        var limit = new int[s.Length];
        for (int p = s.Length - 1; p >= 0; p--)
        {
            limit[p] = s[p] < 'a' ? 0 : (p + 1 < s.Length ? limit[p + 1] : 0) + 1;
        }

        var shared = new int[order.Length];
        var cumulative = new long[order.Length + 1];
        for (int i = 0; i < order.Length; i++)
        {
            shared[i] = Math.Min(lcp[i], limit[order[i]]);
            cumulative[i + 1] = cumulative[i] + (limit[order[i]] - shared[i]);
        }

        return queries.Select(k =>
        {
            if (k < 1 || k > cumulative[^1])
            {
                return "INVALID";
            }

            // The first suffix whose running total reaches k holds the answer.
            int low = 0, high = order.Length - 1;
            while (low < high)
            {
                int mid = (low + high) / 2;
                if (cumulative[mid + 1] >= k) high = mid;
                else low = mid + 1;
            }

            int index = low;
            long within = k - cumulative[index];
            return s.Substring(order[index], shared[index] + (int)within);
        }).ToArray();
    }
}
