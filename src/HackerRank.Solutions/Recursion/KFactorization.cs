namespace HackerRank.Solutions.Recursion;

/// <summary>
/// K Factorization — reach <c>n</c> from 1 by multiplying by numbers from A in as few steps as
/// possible. Return the states visited, choosing the lexicographically smallest sequence on
/// ties, or [-1]. Every state is a divisor of n, so BFS backwards from n (dividing by A)
/// finds each divisor's distance to n. Then walk forwards from 1, always taking the smallest
/// next state that is one step closer.
/// https://www.hackerrank.com/challenges/k-factorization
/// </summary>
public static class KFactorization
{
    public static long[] Solve(long n, IReadOnlyList<long> a)
    {
        var stepsToN = new Dictionary<long, int> { [n] = 0 };
        var queue = new Queue<long>();
        queue.Enqueue(n);

        while (queue.Count > 0)
        {
            long state = queue.Dequeue();
            foreach (var factor in a)
            {
                if (state % factor == 0 && stepsToN.TryAdd(state / factor, stepsToN[state] + 1))
                {
                    queue.Enqueue(state / factor);
                }
            }
        }

        if (!stepsToN.TryGetValue(1, out int remaining))
        {
            return [-1];
        }

        var path = new List<long> { 1 };
        for (long current = 1; remaining > 0; remaining--)
        {
            current = a
                .Where(factor => n / current % factor == 0)
                .Select(factor => current * factor)
                .Where(next => stepsToN.TryGetValue(next, out int steps) && steps == remaining - 1)
                .Min();
            path.Add(current);
        }

        return path.ToArray();
    }
}
