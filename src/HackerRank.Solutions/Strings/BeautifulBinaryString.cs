namespace HackerRank.Solutions.Strings;

/// <summary>
/// Beautiful Binary String — minimum bit flips so the string contains no "010".
/// Each non-overlapping occurrence needs exactly one flip (flipping its last bit).
/// https://www.hackerrank.com/challenges/beautiful-binary-string
/// </summary>
public static class BeautifulBinaryString
{
    public static int Solve(string b)
    {
        int flips = 0;
        int i = 0;

        while (i <= b.Length - 3)
        {
            if (b[i] == '0' && b[i + 1] == '1' && b[i + 2] == '0')
            {
                flips++;
                i += 3;
            }
            else
            {
                i++;
            }
        }

        return flips;
    }
}
