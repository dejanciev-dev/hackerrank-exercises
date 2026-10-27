namespace HackerRank.Solutions.Strings;

/// <summary>
/// String Function Calculation — maximise length · occurrences over all substrings. A
/// substring occurring c ≥ 2 times corresponds to c adjacent suffixes in the suffix array
/// whose LCPs are all at least its length. So this is the largest-rectangle problem on the
/// LCP array, with c = width + 1, compared against the whole string (n · 1). O(n log² n).
/// https://www.hackerrank.com/challenges/string-function-calculation
/// </summary>
public static class StringFunctionCalculation
{
    public static long Solve(string t)
    {
        var lcp = SuffixArray.Lcp(t, SuffixArray.Build(t));
        long best = t.Length;

        // Monotonic stack of (start index, height) over lcp[1..n-1].
        var stack = new Stack<(int Start, int Height)>();

        for (int i = 1; i <= lcp.Length; i++)
        {
            int height = i < lcp.Length ? lcp[i] : 0;
            int start = i;

            while (stack.Count > 0 && stack.Peek().Height >= height)
            {
                var (top, topHeight) = stack.Pop();
                best = Math.Max(best, (long)topHeight * (i - top + 1));
                start = top;
            }

            stack.Push((start, height));
        }

        return best;
    }
}
