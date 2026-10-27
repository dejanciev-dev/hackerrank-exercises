namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Chocolate in Box — a Nim position; how many first moves win? A winning move must leave a
/// nim-sum of 0, which means shrinking some pile a_i to a_i XOR X (X the current nim-sum).
/// That's possible for exactly the piles where a_i XOR X &lt; a_i.
/// https://www.hackerrank.com/challenges/chocolate-in-box
/// </summary>
public static class ChocolateInBox
{
    public static int Solve(IReadOnlyList<int> a)
    {
        int nimSum = a.Aggregate(0, (x, v) => x ^ v);
        return a.Count(v => (v ^ nimSum) < v);
    }
}
