namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Manasa loves Maths — can the digits be rearranged into a multiple of 8? Divisibility by 8
/// depends only on the last three digits. So for long numbers, check whether any three-digit
/// multiple of 8 can be built from the available digits. Shorter numbers just try every
/// permutation.
/// https://www.hackerrank.com/challenges/manasa-loves-maths
/// </summary>
public static class ManasaLovesMaths
{
    public static string Solve(string n)
    {
        if (n.Length <= 3)
        {
            return Permutations(n).Any(p => int.Parse(p) % 8 == 0) ? "YES" : "NO";
        }

        var counts = new int[10];
        foreach (var c in n)
        {
            counts[c - '0']++;
        }

        for (int multiple = 0; multiple < 1000; multiple += 8)
        {
            var needed = new int[10];
            foreach (var c in multiple.ToString("D3"))
            {
                needed[c - '0']++;
            }

            if (needed.Select((need, digit) => need <= counts[digit]).All(ok => ok))
            {
                return "YES";
            }
        }

        return "NO";
    }

    private static IEnumerable<string> Permutations(string s)
    {
        if (s.Length <= 1)
        {
            yield return s;
            yield break;
        }

        for (int i = 0; i < s.Length; i++)
        {
            foreach (var rest in Permutations(s.Remove(i, 1)))
            {
                yield return s[i] + rest;
            }
        }
    }
}
