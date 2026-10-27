namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// New Year Game — Balsa and Koca take turns adding numbers to their own scores; Balsa (who
/// starts) wins unless the score difference is divisible by 3. Only residues mod 3 matter,
/// and multiples of 3 change nothing. Koca can mirror Balsa's 1s and 2s exactly when both
/// residue counts are even.
/// https://www.hackerrank.com/challenges/newyear-game
/// </summary>
public static class NewYearGame
{
    public static string Solve(IReadOnlyList<int> a)
    {
        int ones = a.Count(v => v % 3 == 1);
        int twos = a.Count(v => v % 3 == 2);

        return ones % 2 == 0 && twos % 2 == 0 ? "Koca" : "Balsa";
    }
}
