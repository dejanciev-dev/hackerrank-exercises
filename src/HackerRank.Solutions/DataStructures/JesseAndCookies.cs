namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// Jesse and Cookies — repeatedly combine the two least sweet cookies into one with sweetness
/// least + 2 × second least until every cookie is at least <c>k</c>. Return the number of
/// operations, or -1 if impossible. A min-heap keeps each step at O(log n).
/// https://www.hackerrank.com/challenges/jesse-and-cookies
/// </summary>
public static class JesseAndCookies
{
    public static int Solve(long k, IReadOnlyList<int> a)
    {
        var heap = new PriorityQueue<long, long>(a.Select(v => ((long)v, (long)v)));
        int operations = 0;

        while (heap.Count >= 2 && heap.Peek() < k)
        {
            long least = heap.Dequeue();
            long second = heap.Dequeue();
            long combined = least + 2 * second;

            heap.Enqueue(combined, combined);
            operations++;
        }

        return heap.Peek() >= k ? operations : -1;
    }
}
