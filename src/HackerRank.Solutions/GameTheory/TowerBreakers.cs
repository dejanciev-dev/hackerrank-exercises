namespace HackerRank.Solutions.GameTheory;

/// <summary>
/// Tower Breakers — <c>n</c> towers of height <c>m</c>; a move shrinks a tower to one of its
/// proper divisors. If m is 1 nobody can move, and with an even number of towers player 2
/// copies every move on a paired tower: both cases win for player 2. Otherwise player 1 cuts
/// one tower to 1 and then mirrors. Returns the winner, 1 or 2.
/// https://www.hackerrank.com/challenges/tower-breakers-1
/// </summary>
public static class TowerBreakers
{
    public static int Solve(int n, int m) => m == 1 || n % 2 == 0 ? 2 : 1;
}
