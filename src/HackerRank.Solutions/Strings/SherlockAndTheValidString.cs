namespace HackerRank.Solutions.Strings;

/// <summary>
/// Sherlock and the Valid String — valid when every character occurs equally often, or would
/// after removing a single character. Look at how many characters share each frequency.
/// https://www.hackerrank.com/challenges/sherlock-and-valid-string
/// </summary>
public static class SherlockAndTheValidString
{
    public static string Solve(string s)
    {
        var frequencyOfFrequency = s.GroupBy(c => c)
            .GroupBy(group => group.Count())
            .ToDictionary(group => group.Key, group => group.Count());

        if (frequencyOfFrequency.Count == 1)
        {
            return "YES";
        }

        if (frequencyOfFrequency.Count > 2)
        {
            return "NO";
        }

        var (low, high) = (frequencyOfFrequency.Keys.Min(), frequencyOfFrequency.Keys.Max());

        // Either one character appears exactly once and can be removed...
        bool removeSingleton = low == 1 && frequencyOfFrequency[low] == 1;
        // ...or one character appears exactly once more than all the others.
        bool trimOneExtra = high - low == 1 && frequencyOfFrequency[high] == 1;

        return removeSingleton || trimOneExtra ? "YES" : "NO";
    }
}
