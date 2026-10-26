namespace HackerRank.Solutions.DataStructures;

/// <summary>
/// QHEAP1 — handle "1 v" (add), "2 v" (delete) and "3" (print the minimum). Elements are
/// distinct, so a SortedSet (a balanced BST) gives O(log n) adds, deletes and minimums.
/// https://www.hackerrank.com/challenges/qheap1
/// </summary>
public static class Qheap1
{
    public static int[] Solve(IReadOnlyList<string> queries)
    {
        var heap = new SortedSet<int>();
        var printed = new List<int>();

        foreach (var query in queries)
        {
            var parts = query.Split(' ');

            switch (parts[0])
            {
                case "1":
                    heap.Add(int.Parse(parts[1]));
                    break;
                case "2":
                    heap.Remove(int.Parse(parts[1]));
                    break;
                case "3":
                    printed.Add(heap.Min);
                    break;
            }
        }

        return printed.ToArray();
    }
}
