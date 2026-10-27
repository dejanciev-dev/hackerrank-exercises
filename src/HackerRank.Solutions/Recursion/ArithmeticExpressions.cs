using System.Text;

namespace HackerRank.Solutions.Recursion;

/// <summary>
/// Arithmetic Expressions — put +, - or * between the numbers (evaluated left to right, no
/// precedence) so the result is divisible by 101; one answer is guaranteed to exist. Only
/// the running value mod 101 matters, so search over (position, remainder) states. Each state
/// remembers how it was first reached, and the operators are read back from (n - 1, 0).
/// O(n · 101).
/// https://www.hackerrank.com/challenges/arithmetic-expressions
/// </summary>
public static class ArithmeticExpressions
{
    private const int Mod = 101;

    public static string Solve(IReadOnlyList<int> arr)
    {
        int n = arr.Count;

        // via[i, r]: the operator and previous remainder that first reached remainder r at i.
        var via = new (char Op, int From)?[n, Mod];
        via[0, arr[0] % Mod] = (' ', -1);

        for (int i = 1; i < n; i++)
        {
            int value = arr[i] % Mod;
            for (int r = 0; r < Mod; r++)
            {
                if (via[i - 1, r] is null)
                {
                    continue;
                }

                via[i, (r + value) % Mod] ??= ('+', r);
                via[i, (r - value + Mod) % Mod] ??= ('-', r);
                via[i, r * value % Mod] ??= ('*', r);
            }
        }

        var ops = new char[n];
        for (int i = n - 1, r = 0; i > 0; i--)
        {
            var (op, from) = via[i, r]!.Value;
            ops[i] = op;
            r = from;
        }

        var expression = new StringBuilder().Append(arr[0]);
        for (int i = 1; i < n; i++)
        {
            expression.Append(ops[i]).Append(arr[i]);
        }

        return expression.ToString();
    }
}
