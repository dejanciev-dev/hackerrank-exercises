using System.Text;

namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Encryption — write the text (spaces removed) into a grid with ceil(sqrt(L)) columns, then
/// read it column by column, separating columns with spaces.
/// https://www.hackerrank.com/challenges/encryption
/// </summary>
public static class Encryption
{
    public static string Solve(string s)
    {
        string text = s.Replace(" ", "");
        int columns = (int)Math.Ceiling(Math.Sqrt(text.Length));
        var encrypted = new StringBuilder();

        for (int column = 0; column < columns; column++)
        {
            if (column > 0)
            {
                encrypted.Append(' ');
            }

            for (int i = column; i < text.Length; i += columns)
            {
                encrypted.Append(text[i]);
            }
        }

        return encrypted.ToString();
    }
}
