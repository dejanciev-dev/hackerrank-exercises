namespace HackerRank.Solutions.Implementation;

/// <summary>
/// Append and Delete — can string <c>s</c> be turned into <c>t</c> using exactly <c>k</c>
/// operations, where each operation appends or deletes a character at the end?
/// https://www.hackerrank.com/challenges/append-and-delete
/// </summary>
public static class AppendAndDelete
{
    public static string Solve(string s, string t, int k)
    {
        int minLength = Math.Min(s.Length, t.Length);
        int commonLength = 0;

        for (int i = 0; i < minLength && s[i] == t[i]; i++)
        {
            commonLength++;
        }

        int required = s.Length + t.Length - 2 * commonLength;

        // Not enough operations to delete the differing suffix and append the new one.
        if (required > k)
        {
            return "No";
        }

        // Spare operations can be burned in append/delete pairs.
        if ((k - required) % 2 == 0)
        {
            return "Yes";
        }

        // Deleting from an empty string is a no-op, so we can delete everything and rebuild.
        if (s.Length + t.Length <= k)
        {
            return "Yes";
        }

        return "No";
    }
}
