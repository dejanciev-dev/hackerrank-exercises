namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Waiter — on iteration i, pop every plate off the stack; plates divisible by the i-th prime
/// go to the answer pile B, the rest onto a new stack for the next round. After each round
/// B is emptied top-first into the answer; after q rounds, so is the leftover stack.
/// https://www.hackerrank.com/challenges/waiter
/// </summary>
public static class Waiter
{
    public static int[] Solve(IReadOnlyList<int> number, int q)
    {
        var answers = new List<int>(number.Count);
        var stack = new Stack<int>(number);

        foreach (var prime in Primes(q))
        {
            var divisible = new Stack<int>();
            var rest = new Stack<int>();

            while (stack.Count > 0)
            {
                int plate = stack.Pop();
                (plate % prime == 0 ? divisible : rest).Push(plate);
            }

            answers.AddRange(divisible);
            stack = rest;
        }

        answers.AddRange(stack);
        return answers.ToArray();
    }

    private static IEnumerable<int> Primes(int count)
    {
        var found = new List<int>(count);

        for (int candidate = 2; found.Count < count; candidate++)
        {
            if (found.TakeWhile(p => p * p <= candidate).All(p => candidate % p != 0))
            {
                found.Add(candidate);
                yield return candidate;
            }
        }
    }
}
