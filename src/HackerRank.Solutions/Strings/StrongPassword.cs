namespace HackerRank.Solutions.Strings;

/// <summary>
/// Strong Password — minimum characters to add so the password has at least 6 characters
/// and contains a digit, a lowercase letter, an uppercase letter and a special character.
/// https://www.hackerrank.com/challenges/strong-password
/// </summary>
public static class StrongPassword
{
    private const string SpecialCharacters = "!@#$%^&*()-+";

    public static int Solve(int n, string password)
    {
        int missing = 0;

        if (!password.Any(char.IsAsciiDigit)) missing++;
        if (!password.Any(char.IsAsciiLetterLower)) missing++;
        if (!password.Any(char.IsAsciiLetterUpper)) missing++;
        if (!password.Any(SpecialCharacters.Contains)) missing++;

        return Math.Max(missing, 6 - n);
    }
}
