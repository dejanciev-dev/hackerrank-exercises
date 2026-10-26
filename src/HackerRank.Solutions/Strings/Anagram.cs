namespace HackerRank.Solutions.Strings;

/// <summary>
/// Anagram — split the string into two halves and return the minimum characters to change
/// in one half to make it an anagram of the other, or -1 if the length is odd.
/// https://www.hackerrank.com/challenges/anagram
/// </summary>
public static class Anagram
{
    public static int Solve(string s)
    {
        if (s.Length % 2 != 0)
        {
            return -1;
        }

        int half = s.Length / 2;
        var counts = new int[26];

        for (int i = 0; i < half; i++)
        {
            counts[s[i] - 'a']++;
            counts[s[half + i] - 'a']--;
        }

        // Every surplus letter in the first half must be changed into a missing one.
        return counts.Where(count => count > 0).Sum();
    }
}
