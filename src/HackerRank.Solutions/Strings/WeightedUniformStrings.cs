namespace HackerRank.Solutions.Strings;

/// <summary>
/// Weighted Uniform Strings — letters weigh 1 ('a') to 26 ('z'); a uniform substring is a run
/// of one letter. For each query, answer whether some uniform substring has that weight.
/// https://www.hackerrank.com/challenges/weighted-uniform-string
/// </summary>
public static class WeightedUniformStrings
{
    public static string[] Solve(string s, IReadOnlyList<int> queries)
    {
        var weights = new HashSet<int>();
        int runWeight = 0;

        for (int i = 0; i < s.Length; i++)
        {
            int letterWeight = s[i] - 'a' + 1;
            runWeight = i > 0 && s[i] == s[i - 1] ? runWeight + letterWeight : letterWeight;
            weights.Add(runWeight);
        }

        return queries.Select(query => weights.Contains(query) ? "Yes" : "No").ToArray();
    }
}
