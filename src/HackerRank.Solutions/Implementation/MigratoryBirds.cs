namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Migratory Birds — the most frequently sighted bird type; ties go to the smallest id.
/// https://www.hackerrank.com/challenges/migratory-birds
/// </summary>
public static class MigratoryBirds
{
    public static int Solve(IReadOnlyList<int> arr)
    {
        var types = new SortedDictionary<int, int>();
        foreach (var type in arr)
        {
            types[type] = types.GetValueOrDefault(type) + 1;
        }

        int maxCount = 0;
        int result = 0;
        foreach (var (type, count) in types)
        {
            if (count > maxCount)
            {
                maxCount = count;
                result = type;
            }
        }

        return result;
    }
}
