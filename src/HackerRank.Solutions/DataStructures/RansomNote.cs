namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Hash Tables: Ransom Note — can the note be written using whole words cut from the
/// magazine (case-sensitive, each word used at most once)? Count the magazine's words in a
/// hash map, then spend them on the note. O(m + n).
/// https://www.hackerrank.com/challenges/ctci-ransom-note
/// </summary>
public static class RansomNote
{
    public static string Solve(IReadOnlyList<string> magazine, IReadOnlyList<string> note)
    {
        var available = new Dictionary<string, int>(StringComparer.Ordinal);
        foreach (var word in magazine)
        {
            available[word] = available.GetValueOrDefault(word) + 1;
        }

        foreach (var word in note)
        {
            if (available.GetValueOrDefault(word) == 0)
            {
                return "No";
            }

            available[word]--;
        }

        return "Yes";
    }
}
