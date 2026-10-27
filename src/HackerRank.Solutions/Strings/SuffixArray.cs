namespace HackerRank.Solutions.Strings;

/// <summary>
/// Suffix array (prefix doubling, O(n log² n)) and LCP array (Kasai, O(n)), shared by the
/// substring-counting problems.
/// </summary>
internal static class SuffixArray
{
    /// <summary>Start indices of the suffixes of <paramref name="s"/> in sorted order.</summary>
    public static int[] Build(string s)
    {
        int n = s.Length;
        var order = Enumerable.Range(0, n).ToArray();
        var rank = s.Select(c => (int)c).ToArray();
        var next = new int[n];
        if (n == 0)
        {
            return order;
        }

        for (int length = 1; ; length <<= 1)
        {
            int Second(int i) => i + length < n ? rank[i + length] : -1;
            Array.Sort(order, (a, b) => rank[a] != rank[b] ? rank[a].CompareTo(rank[b]) : Second(a).CompareTo(Second(b)));

            next[order[0]] = 0;
            for (int i = 1; i < n; i++)
            {
                bool same = rank[order[i]] == rank[order[i - 1]] && Second(order[i]) == Second(order[i - 1]);
                next[order[i]] = next[order[i - 1]] + (same ? 0 : 1);
            }

            Array.Copy(next, rank, n);
            if (rank[order[n - 1]] == n - 1)
            {
                return order;
            }
        }
    }

    /// <summary>lcp[i] = longest common prefix of suffixes order[i - 1] and order[i]; lcp[0] = 0.</summary>
    public static int[] Lcp(string s, int[] order)
    {
        int n = s.Length;
        var rank = new int[n];
        for (int i = 0; i < n; i++)
        {
            rank[order[i]] = i;
        }

        var lcp = new int[n];
        int h = 0;

        for (int i = 0; i < n; i++)
        {
            if (rank[i] == 0)
            {
                h = 0;
                continue;
            }

            int j = order[rank[i] - 1];
            while (i + h < n && j + h < n && s[i + h] == s[j + h])
            {
                h++;
            }

            lcp[rank[i]] = h;
            if (h > 0)
            {
                h--;
            }
        }

        return lcp;
    }
}
