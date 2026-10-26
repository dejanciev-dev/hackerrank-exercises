namespace HackerRank.Solutions.Strings;

/// <summary>
/// Making Anagrams — minimum characters to delete from both strings so they become anagrams.
/// https://www.hackerrank.com/challenges/making-anagrams
/// </summary>
public static class MakingAnagrams
{
    public static int Solve(string s1, string s2)
    {
        var counts = new int[26];

        foreach (var c in s1) counts[c - 'a']++;
        foreach (var c in s2) counts[c - 'a']--;

        return counts.Sum(Math.Abs);
    }
}
