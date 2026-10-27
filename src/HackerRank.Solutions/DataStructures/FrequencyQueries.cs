namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Frequency Queries — "1 x" inserts x, "2 y" deletes one y, "3 z" asks whether any value
/// occurs exactly z times. Keep both value → count and count → how many values have it, so
/// every operation is O(1).
/// https://www.hackerrank.com/challenges/frequency-queries
/// </summary>
public static class FrequencyQueries
{
    /// <param name="queries">Each query as <c>[operation, value]</c>.</param>
    public static int[] Solve(IReadOnlyList<IReadOnlyList<int>> queries)
    {
        var count = new Dictionary<int, int>();
        var withCount = new Dictionary<int, int>();
        var answers = new List<int>();

        void Shift(int value, int delta)
        {
            int before = count.GetValueOrDefault(value);
            int after = before + delta;
            withCount[before] = withCount.GetValueOrDefault(before) - 1;
            withCount[after] = withCount.GetValueOrDefault(after) + 1;
            count[value] = after;
        }

        foreach (var query in queries)
        {
            switch (query[0])
            {
                case 1:
                    Shift(query[1], 1);
                    break;
                case 2 when count.GetValueOrDefault(query[1]) > 0:
                    Shift(query[1], -1);
                    break;
                case 3:
                    answers.Add(withCount.GetValueOrDefault(query[1]) > 0 ? 1 : 0);
                    break;
            }
        }

        return answers.ToArray();
    }
}
