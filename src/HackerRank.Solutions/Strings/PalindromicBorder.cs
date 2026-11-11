namespace HackerRank.Solutions.Strings;

/// <summary>
/// Palindromic Border — sum, over every substring of s, the number of its proper borders
/// (prefixes that are also suffixes) that are palindromes, modulo 10^9 + 7.
/// A substring with palindromic border P is fixed by two distinct occurrences of P, the one
/// at its start and the one at its end. So the answer is Σ C(occ(P), 2) over the distinct
/// palindromes P. A palindromic tree (eertree) lists them and counts their occurrences in O(n).
/// https://www.hackerrank.com/challenges/palindromic-border
/// </summary>
public static class PalindromicBorder
{
    public static long Solve(string s)
    {
        int n = s.Length;
        // Node 0: the imaginary root of length −1; node 1: the empty root of length 0.
        var length = new int[n + 2];
        var link = new int[n + 2];
        var occurrences = new long[n + 2];
        var next = new Dictionary<(int Node, char Letter), int>();
        length[0] = -1;
        link[0] = 0;
        link[1] = 0;
        int nodes = 2, last = 1;

        for (int i = 0; i < n; i++)
        {
            char c = s[i];
            int current = SuffixPalindrome(last, i);

            if (!next.TryGetValue((current, c), out int node))
            {
                node = nodes++;
                length[node] = length[current] + 2;
                link[node] = length[node] == 1 ? 1 : next[(SuffixPalindrome(link[current], i), c)];
                next[(current, c)] = node;
            }

            occurrences[node]++;
            last = node;
        }

        // Longer palindromes were created later; pushing counts down the suffix links in
        // reverse creation order gives every palindrome its full occurrence count.
        long answer = 0;
        for (int node = nodes - 1; node >= 2; node--)
        {
            occurrences[link[node]] += occurrences[node];
            answer = (answer + occurrences[node] * (occurrences[node] - 1) / 2) % 1_000_000_007;
        }

        return answer;

        int SuffixPalindrome(int node, int end)
        {
            while (end - length[node] - 1 < 0 || s[end - length[node] - 1] != s[end])
            {
                node = link[node];
            }

            return node;
        }
    }
}
