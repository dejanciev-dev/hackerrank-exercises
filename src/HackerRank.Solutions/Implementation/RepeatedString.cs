namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Repeated String — count the 'a's in the first <c>n</c> characters of <c>s</c> repeated
/// infinitely, without building the string.
/// https://www.hackerrank.com/challenges/repeated-string
/// </summary>
public static class RepeatedString
{
    public static long Solve(string s, long n)
    {
        long fullRepeats = n / s.Length;
        int remainder = (int)(n % s.Length);

        return fullRepeats * CountA(s, s.Length) + CountA(s, remainder);
    }

    private static int CountA(string s, int length)
    {
        int count = 0;
        for (int i = 0; i < length; i++)
        {
            if (s[i] == 'a') count++;
        }

        return count;
    }
}
