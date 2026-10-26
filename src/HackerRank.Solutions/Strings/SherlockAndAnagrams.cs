namespace HackerRank.Solutions.Strings;

/// <summary>
/// Sherlock and Anagrams — count pairs of substrings that are anagrams of each other.
/// Group all substrings by their sorted-letter signature and add C(count, 2) per group.
/// https://www.hackerrank.com/challenges/sherlock-and-anagrams
/// </summary>
public static class SherlockAndAnagrams
{
    public static int Solve(string s)
    {
        var signatures = new Dictionary<string, int>();

        for (int start = 0; start < s.Length; start++)
        {
            for (int length = 1; start + length <= s.Length; length++)
            {
                var letters = s.Substring(start, length).ToCharArray();
                Array.Sort(letters);
                var signature = new string(letters);

                signatures[signature] = signatures.GetValueOrDefault(signature) + 1;
            }
        }

        return signatures.Values.Sum(count => count * (count - 1) / 2);
    }
}
