namespace HackerRank.Solutions.Mathematics;

/// <summary>
/// Special Multiple — the smallest positive multiple of <c>n</c> written only with the digits
/// 9 and 0. BFS over numbers built digit by digit ("0" before "9", so shorter and then
/// smaller numbers come first), keeping one number per remainder mod n. At most n states.
/// https://www.hackerrank.com/challenges/special-multiple
/// </summary>
public static class SpecialMultiple
{
    public static string Solve(int n)
    {
        var seen = new bool[n];
        var queue = new Queue<(string Number, int Remainder)>();
        queue.Enqueue(("9", 9 % n));
        seen[9 % n] = true;

        while (queue.Count > 0)
        {
            var (number, remainder) = queue.Dequeue();
            if (remainder == 0)
            {
                return number;
            }

            foreach (var digit in "09")
            {
                int next = (remainder * 10 + (digit - '0')) % n;
                if (!seen[next])
                {
                    seen[next] = true;
                    queue.Enqueue((number + digit, next));
                }
            }
        }

        throw new InvalidOperationException("Unreachable: some multiple of 9s and 0s always exists.");
    }
}
