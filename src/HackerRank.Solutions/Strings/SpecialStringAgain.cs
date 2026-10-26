namespace HackerRank.Solutions.Strings;

/// <summary>
/// Special String Again — count substrings where all characters are equal, or all are equal
/// except the exact middle one (e.g. "aadaa"). Compress the string into runs: a run of length L
/// gives L(L+1)/2 uniform substrings, and a single-character run between two runs of the
/// same letter adds min(left, right) centered ones. O(n).
/// https://www.hackerrank.com/challenges/special-palindrome-again
/// </summary>
public static class SpecialStringAgain
{
    public static long Solve(string s)
    {
        var runs = new List<(char Letter, int Length)>();
        foreach (var c in s)
        {
            if (runs.Count > 0 && runs[^1].Letter == c)
            {
                runs[^1] = (c, runs[^1].Length + 1);
            }
            else
            {
                runs.Add((c, 1));
            }
        }

        long count = runs.Sum(run => (long)run.Length * (run.Length + 1) / 2);

        for (int i = 1; i < runs.Count - 1; i++)
        {
            if (runs[i].Length == 1 && runs[i - 1].Letter == runs[i + 1].Letter)
            {
                count += Math.Min(runs[i - 1].Length, runs[i + 1].Length);
            }
        }

        return count;
    }
}
