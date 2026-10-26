namespace HackerRank.Solutions.Strings;

/// <summary>
/// String Construction — copying any substring already built is free and appending a
/// character costs 1, so the minimum cost is the number of distinct characters.
/// https://www.hackerrank.com/challenges/string-construction
/// </summary>
public static class StringConstruction
{
    public static int Solve(string s) => s.Distinct().Count();
}
